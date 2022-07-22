using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.Request;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Controllers
{
    

    public class FilmesController : Controller
    {
        private IngressoDbContext _context;

        public FilmesController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Filmes);
        }

        public IActionResult Detalhes(int id)
        {
            var result = _context.Filmes.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Criar(PostFilmeDTO filmesDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Nome == filmesDto.NomeCinema );

            if (cinema == null)
            {
                return View();
            }
            var produtor = _context.Produtores.FirstOrDefault(p => p.Nome == filmesDto.NomeProdutor);

            Filme filme = new Filme(filmesDto.Titulo, filmesDto.Descricao, filmesDto.Preco, filmesDto.ImageURL, cinema.Id, produtor.Id);

            _context.Add(filme);
            _context.SaveChanges();
            //falta fazer a FilmesDTO
            //Incluir relacionamentos
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CriarFilmeComCategoriasAtores(PostFilmeDTO filmeDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Nome == filmeDto.NomeCinema);
            if (cinema == null) return View();
            var produtor = _context.Produtores.FirstOrDefault(p => p.Nome == filmeDto.NomeProdutor);
            if (produtor == null) return View();
            Filme filme = new Filme
                (
                    filmeDto.Titulo,
                    filmeDto.Descricao,
                    filmeDto.Preco,
                    filmeDto.ImageURL,
                    cinema.Id,
                    produtor.Id
                );
            _context.Add(filme);
            _context.SaveChanges();

            //Incluir Relacionamentos
            foreach (var categoria in filmeDto.Categorias)
            {
                int? categoriaId = _context.Categorias.Where(c => c.Nome == categoria).FirstOrDefault().Id;

                if (categoriaId != null)
                {
                    var novaCategoria = new FilmeCategoria(filme.Id, categoriaId.Value);
                    _context.FilmesCategorias.Add(novaCategoria);
                    _context.SaveChanges();
                }
            }

            foreach (var ator in filmeDto.NomeAtores)
            {
                int? atorId = _context.Atores.Where(a => a.Nome == ator).FirstOrDefault().Id;

                if (atorId != null)
                {
                    var novoAtor = new AtorFilme(atorId.Value, filme.Id);
                    _context.AtoresFilmes.Add(novoAtor);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
