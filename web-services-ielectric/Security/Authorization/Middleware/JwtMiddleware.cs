using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Security.Authorization.Handlers.Interfaces;
using web_services_ielectric.Security.Domain.Services;
using web_services_ielectric.Shared.Settings;

namespace web_services_ielectric.Security.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtHandler _jwtUtility;

        public JwtMiddleware(RequestDelegate next, IJwtHandler jwtUtility)
        {
            _next = next;
            _jwtUtility = jwtUtility;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, userService, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            var userId = _jwtUtility.ValidateToken(token);

            if (userId != null)
                context.Items["User"] = userService.GetByIdAsync(userId.Value);
        }
    }
}
