using System;

//PARA FAZER UMA VALIDAÇÃO BASICA DAS INFORMAÇÕES EU USO 
//DATAANNOTACION
using System.ComponentModel.DataAnnotations; 

namespace NetCoders.WebAPI.Services.Models
{
    public class Pessoa
    {
        [Required]
        public Int32 Idade { get; set; }

        [Required]
        public String Nome { get; set; }
    }
}