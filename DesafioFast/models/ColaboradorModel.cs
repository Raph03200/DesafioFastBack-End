using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DesafioFast.models
{
    public class ColaboradorModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage= "Nome do Colaborador é Obrigatório")]
        public string Nome { get; set; }
    }
}