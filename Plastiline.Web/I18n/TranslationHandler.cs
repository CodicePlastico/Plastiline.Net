using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Plastiline.Web.I18n
{
    public class TranslationHandler : DelegatingHandler
    {
        public string FallbackLanguage { get; set; } = "EN";
        public string LanguageCookie { get; set; } = "PreferredLanguage";
        public IEnumerable<string> ExcludedMediaTypes { get; set; } = new string[] { "image/jpeg" };

        private readonly ITranslator _translator;
        private const string LabelPlaceholderRegex = @"\|\#(?<word>\s?[^#]+)#\|";
        public TranslationHandler(ITranslator translator)
        {
            _translator = translator;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Task<HttpResponseMessage> response = base.SendAsync(request, cancellationToken);
            if (response.Result.Content != null && !ExcludedMediaTypes.Contains(response.Result.Content.Headers.ContentType.MediaType))
            {
                byte[] byteResponse = response.Result.Content.ReadAsByteArrayAsync().Result;
                string body = Encoding.UTF8.GetString(byteResponse);
                string lang = ReadTranslationLanguage(request);

                string result = System.Text.RegularExpressions.Regex.Replace(body, LabelPlaceholderRegex, match => TranslateAction(match, lang), RegexOptions.Multiline);
                response.Result.Content = new StringContent(result);

            }
            return response;
        }

        private string ReadTranslationLanguage(HttpRequestMessage request)
        {
            Collection<CookieHeaderValue> cookieHeaderValues = request.Headers.GetCookies();
            string lang = FallbackLanguage;
            if (cookieHeaderValues.Count > 0)
            {
                lang = cookieHeaderValues[0][LanguageCookie].Value;
            }
            return lang;
        }

        private string TranslateAction(Match match, string lang)
        {
            string key = match.Groups["word"].Value;
            string translation = _translator.Translate(key, lang);
            return translation;
        }
    }
}
