using System;
using System.Security.Claims;

namespace IqraCommerce.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid RetrieveIdFromPrincipal(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}