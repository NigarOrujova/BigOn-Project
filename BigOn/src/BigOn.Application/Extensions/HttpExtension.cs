using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace BigOn.Application.Extensions
{
    public static partial class Extension
    {

        public static Dictionary<string, object> AddFromHeader(this Dictionary<string,object> items,
            HttpRequest request,string key)
        {
            if (request.Headers.TryGetValue(key, out StringValues values))
            {
                items.Add(key, values.FirstOrDefault());
            }

            return items;
        }


        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request.Headers != null)
            {
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }

            return false;
        }


        public static TService GetService<TService>(this IActionContextAccessor ctx)
        {
            return ctx.ActionContext.HttpContext.RequestServices.GetService<TService>();
        }

        public static TService GetService<TService>(this IHttpContextAccessor ctx)
        {
            return ctx.HttpContext.RequestServices.GetService<TService>();
        }
    }
}
