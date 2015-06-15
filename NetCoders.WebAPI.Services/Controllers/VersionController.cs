using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NetCoders.WebAPI.Services.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Palestra")]
    public class VersionController : ApiController
    {
        [Route("V1")]
        [HttpGet]
        public HttpResponseMessage VersionV1()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK, "API acessada V1");
        }

        [Route("V2")]
        [HttpGet]
        public HttpResponseMessage VersionV2()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK, "API acessada V2");
        }
    }
}
