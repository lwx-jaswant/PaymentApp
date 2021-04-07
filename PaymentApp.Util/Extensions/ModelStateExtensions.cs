using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Linq;

namespace PaymentApp.Util.Extensions
{
    public static class ModelStateExtensions
    {
        public static string ToJSON(this ModelStateDictionary modelState)
        {
            return JsonConvert.SerializeObject(modelState.Values.SelectMany(m => m.Errors)
                             .Select(e => e.ErrorMessage)
                             .ToList());
        }
    }
}
