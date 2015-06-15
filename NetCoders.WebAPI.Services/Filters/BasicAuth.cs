using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//IMPORTAMOS ALGUMAS DLL PARA VALIDAÇÃO DE USUARIO E SENHA
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Text;
namespace NetCoders.WebAPI.Services.Filters
{
    public class BasicAuth : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;
            var credencials = Encoding.GetEncoding("UTF-8").
                GetString(Convert.FromBase64String(
                    authHeader.Parameter)).Split(':');

            if (credencials[0] == "jean" && credencials[1] == "jean123")
            {
                var user = new GenericPrincipal(
                    new GenericIdentity(credencials[0]), null);

                Thread.CurrentPrincipal = user;
                HttpContext.Current.User = user;
            }
            else
            {
                Thread.CurrentPrincipal = null;
                HttpContext.Current.User = null;
            }
        }

    }
}