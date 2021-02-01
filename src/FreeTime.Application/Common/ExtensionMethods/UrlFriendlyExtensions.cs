using System.Text.RegularExpressions;

namespace FreeTime.Application.Common.ExtensionMethods
{
    public static class UrlFriendlyExtensions
    {
        public static string Friendly(this string url)
        {
            url = url.RemoveWithSpaces();
            return url.Trim();
        }
        public static string RemoveWithSpaces(this string value)
        {
            value = Regex.Replace(value, "[ ]{1,}", "-");
            return value;
        }

    }
}
