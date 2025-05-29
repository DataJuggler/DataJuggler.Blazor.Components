using Microsoft.AspNetCore.Http;
using System;

namespace DataJuggler.Blazor.Components
{
    public class CookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetCookie(string key, string value, int? expireDays = 7)
        {
            var options = new CookieOptions
            {
                Expires = expireDays.HasValue ? DateTimeOffset.Now.AddDays(expireDays.Value) : null,
                HttpOnly = true,
                Secure = true, // Use only if your app uses HTTPS
                SameSite = SameSiteMode.Strict
            };

            _httpContextAccessor.HttpContext?.Response.Cookies.Append(key, value, options);
        }

        public string GetCookie(string key)
        {
            return _httpContextAccessor.HttpContext?.Request.Cookies[key];
        }

        public void DeleteCookie(string key)
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete(key);
        }
    }

}
