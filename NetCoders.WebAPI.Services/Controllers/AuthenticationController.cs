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

//IMPORTAMOS AS CLASSES DE FILTERS PARA QUE POSSAMOS IMPORTAR A VALIDÃÇÃO DE USUARIO 
//EM NOSSA SOLICITAÇAÕ
using NetCoders.WebAPI.Services.Filters;

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

    //APLICAMOS UM PREFIXO DE ROTA
    [RoutePrefix("Auth")]
    public class AuthenticationController : ApiController
    {
        //APLICAMOS UMA ROTA
        [Route("Authentication")]
        [HttpGet]

        //IMPORTAMOS A CLASSE DE AUTENTICAÇÃO PARA NOSSA CONTROLLER
        [BasicAuth]
        public HttpResponseMessage AuthGet()
        {
            //VERIFICAMOS SE A VARIAVEL USER QUE HERDA DE IPRINCIPAL ESTA DIFERENTE DE NULL
            //CASO CONTRARIO O USUARIO ESTA LOGADO
            //PELA CAMADA DE BASICAUTH
            if (User != null)
            {

                //RETORNAMOS O NOME DO USUARIO LOGADO NA APLICAÇÃO
                return Request.CreateResponse(
                    HttpStatusCode.Accepted,
                    String.Format("usuario logado {0}", User.Identity.Name));
            }
            return Request.CreateResponse(
                HttpStatusCode.Unauthorized, "Usuario não autoriado");
        }
    }
}
