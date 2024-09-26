using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PROJECT._360.TokenHelper
{
    public class JwtAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization?.Parameter;

            if (string.IsNullOrEmpty(token))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized.");
                return;
            }

            var tokenValidator = new TokenValidator();
            var principal = tokenValidator.ValidateToken(token);

            if (principal == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Token geçersiz veya süresi dolmuş.");
                return;
            }

            HttpContext.Current.User = principal;
            base.OnAuthorization(actionContext);
        }
    }
}