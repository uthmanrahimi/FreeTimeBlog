using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace FreeTime.Web.Application.Extensions
{
    public static class ModelStateExtensions
    {
        public static bool IsNotValid(this ModelStateDictionary modelState)
        {
            return !modelState.IsValid;
        }

        public static List<string> Errors(this ModelStateDictionary modelState)
        {
            List<string> result = new List<string>();
            foreach (var error in modelState.Values)
            {
                foreach (var item in error.Errors)
                {
                    result.Add(item.ErrorMessage);
                }
            }
            return result;
        }
    }
}
