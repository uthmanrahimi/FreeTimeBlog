using System.Text.RegularExpressions;

namespace FreeTime.Web.Application.Extensions
{
    public static class UrlFriendlyExtensions
    {
        public static string Friendly(this string url)
        {
            url= RemoveWithSpaces(url);
            return url.Trim();
        }
        public static string RemoveWithSpaces(this string value)
        {
            value = Regex.Replace(value, "[ ]{1,}", "-");
            return value;
        }
        
    }
}
