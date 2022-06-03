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
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Nome == Filme.NomeCinema);

            if (cinema = null)
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
        public IActionResult Atualizar()
        {
            //buscar o ator no banco
            //passar o ator na view
            return View();
        }

        public IActionResult Deletar()
        {   //buscar o ator no banco
            //passar o ator na view
            return View();
        }



    }
}
