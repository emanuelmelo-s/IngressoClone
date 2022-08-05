using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class Filme : IEntidade
    {
        public Filme(string titulo, string descricao, decimal preco, string imageURL,int produtorId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            ImageURL = imageURL;
            ProdutorId = produtorId;
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;

        }

        public Filme(string titulo, string descricao, decimal preco, string imageURL, int cinemaId, int produtorId )
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            ImageURL = imageURL;
            ProdutorId = produtorId;
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;


        }

        public int Id { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string ImageURL { get; private set; }

        public void AlterarDados(decimal novoPreco, string novoTitulo, string novoDescricao, string novoImageURL, int produtorId, int cinemaId)
        {
            if (novoTitulo.Length < 3 || novoPreco < 0)
            {
                return;
            }
            Titulo = novoTitulo;
            Descricao = novoDescricao;
            ImageURL = novoImageURL;
            Preco = novoPreco;
            ProdutorId = produtorId;
            CinemaId = cinemaId;

            DataAlteracao = DateTime.Now;
            
        }

        #region relacionamentos
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public int ProdutorId { get; set; }
        public Produtor Produtor{ get; set; }
        public List<AtorFilme> AtoresFilmes { get; set; }
        public List<FilmeCategoria> FilmesCategorias { get; set; }


        #endregion




    }
}
