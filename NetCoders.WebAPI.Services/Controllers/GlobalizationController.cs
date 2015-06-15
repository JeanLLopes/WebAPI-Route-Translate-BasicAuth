using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using NetCoders.WebAPI.Services.Resources;

namespace NetCoders.WebAPI.Services.Controllers
{
    [RoutePrefix("Translate")]
    public class GlobalizationController : ApiController
    {
        [Route("Get")]
        [HttpGet]
        public HttpResponseMessage TraduzGet()
        {
            //CRIAMOS UMA VARIAVEL PARA PEGAR A LIGUAGEM 
            //SOLICITADA PELO CLIENTE
            var language = Thread.CurrentThread.CurrentCulture;

            //RETORNAMOS UMA MENSAGEM CONFORME IDIOMA
            //SOLICITADO PELO CLIENTE
            return Request.CreateResponse(
                HttpStatusCode.OK, Resource.Message);
        }
    }
}
