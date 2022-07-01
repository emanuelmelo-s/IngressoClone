using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using IngressoMVC.Models.ViewModels.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Controllers
{
    public class AtoresController : Controller
    {
        private IngressoDbContext _context;

        public AtoresController(IngressoDbContext context)
        {
            _context = context;
        }
        //GetAtoresDTO

        public IActionResult Index()
        {
            return View(_context.Atores);
        }

        public IActionResult Detalhes(int id)
        {
            var ator = _context.Produtores.Find(id);
            var result = _context.Atores.Where(at => at.Id == id)
                .Select(at => new GetAtoresDTO()
                {
                    Bio = at.Bio,
                    FotoPerfilURL = at.FotoPerfilURL,
                    Nome = at.Nome,
                    NomeFilmes = at.AtoresFilmes.Select(fm => fm.Filme.Titulo).ToList(),
                    FotoURLFilmes = at.AtoresFilmes.Select(fm => fm.Filme.ImageURL).ToList(),
                }).FirstOrDefault();

            return View(result);
        }

        public IActionResult Criar()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Criar(PostAtorDTO atorDto)
        {
            //receber os dados
            //validar os dados
            if (!ModelState.IsValid || !atorDto.FotoPerfilURL.EndsWith(".jpg"))
            {
                return View(atorDto);
            }
            //instanciar um novo ator que receba os dados
            Ator ator = new Ator(atorDto.Nome, atorDto.Bio, atorDto.FotoPerfilURL);
            
            //gravar o ator no banco de dados e salvar as mudanças
            _context.Atores.Add(ator);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

            
        }

       

        //public IActionResult Criar([Bind("Nome,Bio,FotoPerfilURL")] Ator ator)
        //{
        //    //receber os dados
        //    //validar os dados
        //    //instanciar um novo ator que receba os dados
        //    //gravar o ator no banco de dados e salvar as mudanças
        //    _context.Atores.Add(ator);

        //    //salvar as mudanças
        //    _context.SaveChanges();

        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return View();
            //buscar o ator no banco
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                return View();
            }
            //passar o ator na view
            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostAtorDTO atorDTO)
        {
            if (!ModelState.IsValid)
                return View(atorDTO);
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);

            result.AtualizarDados(atorDTO.Nome, atorDTO.Bio, atorDTO.FotoPerfilURL);
            _context.Update(result);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Deletar(int id)
        {   //buscar o ator no banco
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);

            if (result == null) return View();
            //passar o ator na view
            return View(result);
        }

        [HttpPost]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);
            _context.Atores.Remove(result);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
