using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostProdutorDTO
    {
        [Required(ErrorMessage = "Nome do Produtor é Obrigatório!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome do produtor deve ter no máximo 50 caracteres e no mínimo de 3")]
        public string Nome { get; set; }


        public string Bio { get; set; }

        [Required(ErrorMessage ="Imagem é obrigatória !!!")]
        
        public string FotoPerfilURL { get;  set; }
    }
}
