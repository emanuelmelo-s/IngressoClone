using System.Collections.Generic;

namespace IngressoMVC.Models.ViewModels.Request
{
    public class PostFilmeDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImageURL { get; set; }
        public string NomeCinema { get; set; }

        public int ProdutorId { get; set; }
        public int CinemaId { get; set; }

        public List<int> AtoresId { get; set; }
        public List<int> CategoriasId { get; set; }



    }
}