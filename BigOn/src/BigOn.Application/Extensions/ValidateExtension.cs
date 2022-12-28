using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.RegularExpressions;

namespace BigOn.Application.Extensions
{
    public static partial class Extension
    {
        static public bool IsEmail(this string value)
        {
            return Regex.IsMatch(value, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }


        static public IActionContextAccessor AddModelError(this IActionContextAccessor ctx, string propertyName, string error)
        {
            ctx.ActionContext.ModelState.AddModelError(propertyName, error);

            return ctx;
        }
    }
}
