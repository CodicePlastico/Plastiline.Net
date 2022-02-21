using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace Plastiline.Web.I18n
{
    public class TranslationHandler : DelegatingHandler
    {
        public static string FallbackLanguage { get; set; } = "EN";
        public static string LangHeader { get; set; } = "Accept-Language";
        public IEnumerable<string> ExcludedMediaTypes { get; set; } = new string[] { "image/jpeg" };
        
        private readonly ITranslator _translator;
        private const string LabelPlaceholderRegex = @"\|\#(?<word>\s?[^#]+)#\|";
        public TranslationHandler(ITranslator translator)
        {
            _translator = translator;
        }
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = base.SendAsync(request, cancellationToken);
            if (ExcludedMediaTypes.Contains(response.Result.Content.Headers.ContentType?.MediaType)) 
                return response;
            var byteResponse = response.Result.Content.ReadAsByteArrayAsync(cancellationToken).Result;
            var body = Encoding.UTF8.GetString(byteResponse);
            var lang = ReadTranslationLanguage(request);
        
            var result = Regex.Replace(body, LabelPlaceholderRegex, match => TranslateAction(match, lang), RegexOptions.Multiline);
            response.Result.Content = new StringContent(result);
            return response;
        }
        
        private static string ReadTranslationLanguage(HttpRequestMessage request) {
            var userLangs = request.Headers.GetValues(LangHeader).ToString();
            var firstLang = userLangs?.Split(',').FirstOrDefault();
            return string.IsNullOrEmpty(firstLang) ? FallbackLanguage : firstLang;
        }
        
        private string TranslateAction(Match match, string lang)
        {
            var key = match.Groups["word"].Value;
            var translation = _translator.Translate(key, lang);
            return translation;
        }
    }
}
