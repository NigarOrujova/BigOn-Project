using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Security.Claims;

namespace BigOn.Application.Extensions
{
    public static partial class Extension
    {

        public static int? GetUserId(this ClaimsPrincipal principal)
        {
            var nameIdentifier = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (nameIdentifier == null)
            {
                return null;
            }

            return Convert.ToInt32(nameIdentifier);
        }

        public static int? GetUserId(this IActionContextAccessor ctx)
        {
            return ctx.ActionContext.HttpContext.User.GetUserId();
        }

        public static int? GetUserId(this HttpContext ctx)
        {
            return ctx.User.GetUserId();
        }

        public static bool HasAccess(this ClaimsPrincipal principal,string claimName)
        {
            return principal.IsInRole("sa") || principal.HasClaim(c => c.Type.Equals(claimName) && c.Value.Equals("1"));
        }
    }
}
