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

        public string NomeProdutor { get; set; }

        public List<string> NomeAtores { get; set; }
        public List<string> Categorias { get; set; }



    }
}