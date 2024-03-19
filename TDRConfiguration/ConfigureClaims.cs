using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TDR.ViewModels.Usuario;

namespace TDRConfiguration
{
    public static class ConfigureClaims
    {
        public static async Task ConfigureLogIn(HttpContext httpContext, ReadUserViewModel user)
        {
            if (user is null || httpContext is null)
                return;

            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()!),
                new Claim("Email", user!.Email),
                new Claim("Period", user.PeriodFk.ToString())
            };

            var clamsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true
            };

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(clamsIdentity), properties);
        }

        public static async Task ConfigureLogOut(HttpContext httpContext)
        {
            if (httpContext is null) return;

            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
