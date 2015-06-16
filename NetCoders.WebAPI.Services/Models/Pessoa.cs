using System;

//PARA FAZER UMA VALIDAÇÃO BASICA DAS INFORMAÇÕES EU USO 
//DataAnnotations
using System.ComponentModel.DataAnnotations; 

namespace NetCoders.WebAPI.Services.Models
{
    public class Pessoa
    {

        //VAMOS USAR O DATAANNOTACIONS PARA FAZER UMA VALIDAÇAÕ SIMPLES DA APLICAÇÃO
        //ASSIM PODEMOS VALIDAR SE OS DADOS FORAM RECEBIDOS OU NAÕ PELO USUARIO
        //USAMOS O REQUIRED PARA VALIDAR AS INFORMAÇÕES
        [Required]
        public Int32 Idade { get; set; }

        [Required]
        public String Nome { get; set; }
    }
}