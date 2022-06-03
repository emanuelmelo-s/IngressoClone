using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostCategoriaDTO
    {
        [Required,StringLength(50, MinimumLength =4, ErrorMessage ="O nome da categoria não é valida!")]
        public string Nome { get;  set; }
    }
}
