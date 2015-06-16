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
    //AQUI PODEMOS HABILITAR OS CORS DA NOSSA APLICAÇÃO
    //CASO QUEIRAMOS PODEMOS COLOCAR RESTRIÇÕES POR
    //origins: ORIGEM DE SOLICITAÇÃO
    //headers: TIPOS DE CABEÇÃLHO DA SOLICITAÇÃO
    //methods: METODOS DE ENVIO (get, post, put, delete,...)
    //[EnableCors(origins:"www.uol.com.br,http://www.terra.com.br", headers:"Authorization",methods:"get,post")]

    //COLOCAR EM TODOS AS CONTROLLERS
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {

        //DEVEMOS FAZER UMA ANOTAÇÃO NO CABEÇALHO DE CADA METODO
        //INFORMANDO QUAL O MÉTODO HTTP SERÁ USADO PARA A REQUISIÇÃO.
        [HttpGet]

        //COMO PATTERN PARA UMA WEBAPI DEVEMOS SEMPRE RESPONDER AS SOLICITAÇÕES EXTERNAS COM HTTPRESPONSEMESSAGE
        //POIS ASSIM CRIAMOS UM PADRÃO DE RESPONTA USANDO O PROTOCOLO COMPO BASE PARA RESPOTA.
        public HttpResponseMessage TestandoGet()
        {
            //CRIAMOS UMA RESPOSTA COM O 'CreateResponse' E EM SEGUIDA PASSAMOS OS PARAMETRO DE STATUS HTTP DE RESPOSTA DA SOLICITAÇÃO
            //E OBJETO A SER RETORNADO
            return Request.CreateResponse(
                HttpStatusCode.NotFound, "Retorno do GET OK");
        }


        //PARA SOLICITAÇÕES POST, PODEMOS INSERIR O HTTPPOST COMO ANNOTACION DA SOLICITAÇÃO
        [HttpPost]
        public HttpResponseMessage TestandoPost([FromBody]Pessoa dados)
        {
            //PARA O METODO POST, CRIAMOS UM TIPO DE VALIDAÇÃO PELA CLASSE DE MODELO
            //ONDE VALIDAMOS O MODELO DOS DADOS RECEBIDOS PELO SERVIÇO
            if (ModelState.IsValid)
            {
                //APOS TERMOS OS DADOS RECEBIDOS E VALIDADOS, PODEMOS TRABALHAR COM UMA GRAVAÇÃO NO BANCO DE DADOS
                //CASO QUEIRAMOS USAR ESSE TIPO DE SISTEMA
                return Request.CreateResponse(
                    HttpStatusCode.Created, dados);
            }

            //CASO O MODELO NÃO SEJA RESPEITADO PODEMOS INVALIDAR A AÇÃO DO USUARIO
            //E REENVIAR UMA RESPOSTA HTTP PARA A SOLICITAÇÃO
            //NEGANDO O ACESSO A API
            return Request.CreateResponse(
                HttpStatusCode.Unauthorized, "Não foi possivel");
        }
    }
}
