using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FreeTime.Web.Application.Extensions
{
    public static class ModelStateExtensions
    {
        public static bool IsNotValid(this ModelStateDictionary modelState)
        {
            return !modelState.IsValid;
        }
    }
}
