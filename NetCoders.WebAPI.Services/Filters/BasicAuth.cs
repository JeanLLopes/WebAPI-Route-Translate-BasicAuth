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

    //NOSSA CLASSE DEVE HERDAR DE AuthorizationFilterAttribute PARA QUE POSSAMOS EFETUAR UMA VALIDAÇÃO BASICA
    //ASSIM PODEMOS CAPTURAR A SOLICITAÇÃO E DESCRIPTOGRAFAR O CABEÇALHO DA SOLICITAÇÃO
    public class BasicAuth : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            //CAPTURAMOS A PROPRIEDADE Authorization DO CABEÇALHO DE NOSSA SOLICITAÇÃO
            var authHeader = actionContext.Request.Headers.Authorization;

            //DESCRIPTOGRAFAMOS O CABEÇALHO
            //QUE ESTAVA CRIPTOGRAFADO EM BASE64
            var credencials = Encoding.GetEncoding("UTF-8").
                GetString(Convert.FromBase64String(
                    authHeader.Parameter)).Split(':');

            //EFETUAMOS UMA BVALIAÇAÕ SIMPLES ENCIMA DOS DADOS RECEBIDOS
            //NESSE MOMENTO PODEMOS EFETUAR DIVERSAS VALIDAÇÕES ENTRE USUARIO E SENHA , SCHEMA, TIPO DE SOLICITAÇÃO.
            if (credencials[0] == "jean" && credencials[1] == "jean123")
            {
                //CASO O USUARIO ESTAJA CORRETO VAMOS IDENTIFICAR O USUARIO CARREGADO
                var user = new GenericPrincipal(
                    new GenericIdentity(credencials[0]), null);

                //INSERIMOS AS INFORMAÇÕES NA THREAD PRINCIPAL E NO HTTP CURRENT
                Thread.CurrentPrincipal = user;
                HttpContext.Current.User = user;
            }
            else
            {
                //CASO O USUARIO NÃO SEJA O CORRETO DEVEMOS DEIXAR AS VARIAVEIS COMO NULL
                Thread.CurrentPrincipal = null;
                HttpContext.Current.User = null;
            }
        }

    }
}