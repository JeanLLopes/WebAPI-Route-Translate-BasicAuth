using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
//IMPORTAMOS A DLL PARA HABILITAR OS CORS DA MINHA API
//CHAMAR EM TODOS OS CONTROLLERS
//install-package Microsoft.AspNet.WebAPI.Cors
using System.Web.Http.Cors;

//PARA FAZER A TRADUÇÃO DO NOSSO RETORNO USAMOS OS ARQUIVOS DE RESORCES
//AGOR IMPORTAMOS OS ARQUIVOS DE RESOURCES PARA A CONTROLLER
using NetCoders.WebAPI.Services.Resources;

namespace NetCoders.WebAPI.Services.Controllers
{

    //AQUI PODEMOS HABILITAR OS CORS DA NOSSA APLICAÇÃO
    //CASO QUEIRAMOS PODEMOS COLOCAR RESTRIÇÕES POR
    //origins: ORIGEM DE SOLICITAÇÃO
    //headers: TIPOS DE CABEÇÃLHO DA SOLICITAÇÃO
    //methods: METODOS DE ENVIO (get, post, put, delete,...)
    //[EnableCors(origins:"www.uol.com.br,http://www.terra.com.br", headers:"Authorization",methods:"get,post")]

    //COLOCAR EM TODOS AS CONTROLLERS
    [EnableCors(origins: "*", headers: "*", methods: "*")]


    //APLICAMOS UM PREFIXO DE ROTA DE ACESSO A NOSSA API
    [RoutePrefix("Translate")]
    public class GlobalizationController : ApiController
    {

        //APLICAMOS UMA ROTA DE ACESSO A NOSSA API
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
