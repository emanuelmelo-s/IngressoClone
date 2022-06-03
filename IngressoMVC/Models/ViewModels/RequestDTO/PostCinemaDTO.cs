using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostCinemaDTO
    {
        [Required(ErrorMessage = "O nome não é válido !")]
        [StringLength(50, MinimumLength =3,ErrorMessage ="Tamanho do texto inválido!")]
        public string Nome { get;  set; }

        public string Descricao { get;  set; }

        [Required(ErrorMessage ="Foto requerida")]
        public string LogoURL { get;  set; }
    }
}
