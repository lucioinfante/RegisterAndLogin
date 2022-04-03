using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace RegisterAndLoginApp.Controllers
{
    internal class CustomAuthorizedAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userName = context.HttpContext.Session.GetString("username");

            if (userName == null)
            {
                // session "username" variable is not set. Deny access by sending them to the login page.
                context.Result = new RedirectResult("/login");
            }
            else
            {
                // do nothing. let the session proceed.
            }
        }
    }
}