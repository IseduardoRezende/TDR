using System.Security.Claims;

namespace TDR.Extensions
{
    public static class ControllerExtensions
    {
        public static bool IsLogged(this HttpContext context)
        {
            return context?.User?.Identity?.IsAuthenticated ?? false;
        }
        
        public static object? GetClaimValueByType(this ClaimsPrincipal user, string type)
        {
            if (string.IsNullOrEmpty(type))
                return null;

            return user.Claims.FirstOrDefault(c => c.Type.Equals(type, StringComparison.OrdinalIgnoreCase))?.Value;
        }        

        public static bool IsValidIdQueryParam(this long? id, ClaimsPrincipal user)
        {
            return Convert.ToInt64(user.GetClaimValueByType("Id")) == id;
        }
    }
}
