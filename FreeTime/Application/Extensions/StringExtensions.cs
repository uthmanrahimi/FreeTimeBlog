using System.Text.RegularExpressions;

namespace FreeTime.Web.Application.Extensions
{
    public static class StringExtensions
    {
        public static string StripHTML(this string str)
        {
            return Regex.Replace(str, "<.*?>",string.Empty);
        }
    }
}
