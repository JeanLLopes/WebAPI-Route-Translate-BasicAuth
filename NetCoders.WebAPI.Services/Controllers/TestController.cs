using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//IMPORTAMOS A CLASSE DE MODELOS
using NetCoders.WebAPI.Services.Models;

//IMPORTAMOS A DLL PARA HABILITAR OS CORS DA MINHA API
//CHAMAR EM TODOS OS CONTROLLERS
//install-package Microsoft.AspNet.WebAPI.Cors
using System.Web.Http.Cors;

namespace NetCoders.WebAPI.Services.Controllers
{

    //COLOCAR EM TODOS AS CONTROLLERS
    //[EnableCors(origins:"www.uol.com.br,http://www.terra.com.br", headers:"Authorization",methods:"get,post")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage TestandoGet()
        {
            return Request.CreateResponse(
                HttpStatusCode.NotFound, "Retorno do GET OK");
        }



        [HttpPost]
        public HttpResponseMessage TestandoPost([FromBody]Pessoa dados)
        {
            if (ModelState.IsValid)
            {
                //CONEXAO COM MEU BANCO E GUARDAR OS DADOS
                return Request.CreateResponse(
                    HttpStatusCode.Created, dados);
            }
            return Request.CreateResponse(
                HttpStatusCode.Unused, "Não foi possivel");
        }
    }
}
