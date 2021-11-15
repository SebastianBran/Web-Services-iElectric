using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Security.Domain.Entities;

namespace web_services_ielectric.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];

            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) 
                    { StatusCode = StatusCodes.Status401Unauthorized };
            }

            //throw new NotImplementedException();
        }
    }
}
