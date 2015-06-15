using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using NetCoders.WebAPI.Services.Filters;

namespace NetCoders.WebAPI.Services.Controllers
{
    //COLOCAR EM TODOS AS CONTROLLERS
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Auth")]
    public class AuthenticationController : ApiController
    {
        [Route("Authentication")]
        [HttpGet]
        [BasicAuth]
        public HttpResponseMessage AuthGet()
        {
            if (User != null)
            {
                return Request.CreateResponse(
                    HttpStatusCode.Accepted,
                    String.Format("usuario logado {0}", User.Identity.Name));
            }
            return Request.CreateResponse(
                HttpStatusCode.Unauthorized, "Usuario não autoriado");
        }
    }
}
