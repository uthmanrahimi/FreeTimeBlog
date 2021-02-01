using System.Text.RegularExpressions;

namespace FreeTime.Web.Application.Extensions
{
    public static class StringExtensions
    {
        public static string StripHTML(this string str)
        {
            return Regex.Replace(str, "<.*?>",string.Empty);
        }
        public static string SafeSubstring(this string value,int maxLength = 20)
        {
            int length = value.Length >= maxLength ? maxLength : value.Length;
            return $"{value.Substring(0, length)}";
        }
    }
}
