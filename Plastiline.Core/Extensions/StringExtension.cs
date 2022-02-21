namespace Plastiline.Core.Extensions
{
    public static class StringExtension
    {
        private static string UpdateFirst(string arg, Func<string, string> updater)
        {
            var result = arg;
            if (!string.IsNullOrEmpty(arg))
            {
                result = updater(result.Substring(0, 1).ToUpper()) + result.Substring(1, result.Length - 1);
            }
            return result;
        }

        public static string CapFirst(this string self)
        {
            return UpdateFirst(self, s => s.ToUpper());
        }

        public static string UncapFirst(this string self)
        {
            return UpdateFirst(self, s => s.ToLower());
        }
    }
}
