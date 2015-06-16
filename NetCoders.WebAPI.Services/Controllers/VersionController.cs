using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//IMPORTAMOS A DLL PARA HABILITAR OS CORS DA MINHA API
//CHAMAR EM TODOS OS CONTROLLERS
//install-package Microsoft.AspNet.WebAPI.Cors
using System.Web.Http.Cors;

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

    //PARA ALTERAR O PREFIXO DE ROTA DA NOSSA APLICAÇÃO, VAMOS USAR O REOUTEPREFIX
    //COM ELE PODEMOS ALTERAR NOSSA ROTA DE ACESSO A NOSSA API
    //SEM ALTERAR O ARQUIVO DE CONFIGURAÇÕES DE ROTA "WebApiConfig"
    [RoutePrefix("Palestra")]
    //AGORA VAMOS ACESSAR NOSSA API COM A SEGUINTE CHAMADA
    //ex: http:localhost:8080/Palestra
    public class VersionController : ApiController
    {

        //COM O ATRIBUTO ROUTE, PODEMOS ALTERAR A ROTA DE NOSSA SOLICITAÇÃO
        //ONDE ALTERAMOS NOVAMENTE A ROTA, SEM NENHUMA ALTERAÇÃO NO ARQUIVO DE ROTA "WebApiConfig"
        //AGORA NOSSA API TERA A SEGUINTE ROTA DE ACESSO
        //http://localhost:8080/Palestra/V1
        [Route("V1")]
        [HttpGet]
        public HttpResponseMessage VersionV1()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK, "API acessada V1");
        }


        //AGORA NOSSA API TERA A SEGUINTE ROTA DE ACESSO
        //http://localhost:8080/Palestra/V2
        [Route("V2")]
        [HttpGet]
        public HttpResponseMessage VersionV2()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK, "API acessada V2");
        }
    }
}
