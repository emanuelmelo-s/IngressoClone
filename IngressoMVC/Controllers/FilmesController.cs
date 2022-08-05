using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.Request;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var result = _context.Filmes.Include(p => p.Produtor)
                                        .Include(c => c.Cinema)
                                        .Include(fc => fc.FilmesCategorias).ThenInclude(c => c.Categoria)
                                        .Include(af => af.AtoresFilmes).ThenInclude(a => a.Ator)
                                        .FirstOrDefault(f => f.Id == id);

            return View(result);
        }

        
        public IActionResult Criar()
        {
            return View();
           
        }

        public IActionResult Atualizar(int id)
        {
            var resultado = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (resultado == null)
            {
                return View("NotFound");
            }
            return View(resultado);
        }

        public IActionResult Deletar(int id)
        {
            var resultado = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (resultado == null)
            {
                return View("NotFound");
            }

            return View(resultado);
        }

        [HttpPost, ActionName ("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var resultado = _context.Filmes.FirstOrDefault(x => x.Id == id);

            _context.Remove(resultado);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostFilmeDTO filmeDTO)
        {
            var resultado = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
            {
                return View(resultado);
            }

            resultado.AlterarDados(filmeDTO.Preco, filmeDTO.Titulo, filmeDTO.Descricao, filmeDTO.ImageURL, filmeDTO.ProdutorId, filmeDTO.CinemaId) ;
     
            _context.Update(resultado);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Criar(PostFilmeDTO filmeDto)
        {
            Filme filme = new Filme(filmeDto.Titulo, filmeDto.Descricao, filmeDto.Preco, filmeDto.ImageURL, _context.Produtores.FirstOrDefault(x => x.Id == filmeDto.ProdutorId).Id); ;

            _context.Add(filme);
            _context.SaveChanges();
            //falta fazer a FilmesDTO
            //Incluir relacionamentos
            foreach (var categoria in filmeDto.CategoriasId)
            {
                int? categoriaId = _context.Categorias.Where(c => c.Id == categoria).FirstOrDefault().Id;

                if (categoriaId != null)
                {
                    var novaCategoria = new FilmeCategoria(filme.Id, categoriaId.Value);
                    _context.FilmesCategorias.Add(novaCategoria);
                    _context.SaveChanges();
                }
            }

            foreach (var atorId in filmeDto.AtoresId)
            {
                
                    var novoAtor = new AtorFilme(atorId, filme.Id);
                    _context.AtoresFilmes.Add(novoAtor);
                    _context.SaveChanges();
              
            }

            return RedirectToAction(nameof(Index));


        }

       

    }
}
