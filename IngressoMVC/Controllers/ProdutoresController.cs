using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Controllers
{
    public class ProdutoresController : Controller
    {
        private IngressoDbContext _context;

        public ProdutoresController(IngressoDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.Produtores);
        }

        public IActionResult Detalhes(int id)
        {
            var result = _context.Produtores.Find(id);
            return View(result);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Criar(PostProdutorDTO produtorDTO)
        {
            if (!ModelState.IsValid || !produtorDTO.FotoPerfilURL.EndsWith(".jpg"))
            {
                return View(produtorDTO);
            }

            Produtor produtor = new Produtor(produtorDTO.Nome, produtorDTO.Bio,produtorDTO.FotoPerfilURL);

            _context.Produtores.Add(produtor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return View();

            var result = _context.Produtores.FirstOrDefault(a => a.Id == id);
            if (result == null)
                return View();

            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostProdutorDTO produtorDTO)
        {
            //buscar o produtor no banco
            var result = _context.Produtores.FirstOrDefault(a => a.Id == id);
            result.AtualizarDados(produtorDTO.Nome, produtorDTO.Bio, produtorDTO.FotoPerfilURL);
            _context.Update(result);
            _context.SaveChanges();
            //passar o produtor  na view
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Produtores.FirstOrDefault(a => a.Id == id);
            if (result == null) return View();
            return View(result);
        }
        
        [HttpPost]
        public IActionResult ConfirmarDeletar(int id)
        {   //buscar o produtor no banco
            var result = _context.Produtores.FirstOrDefault(a => a.Id == id);
            _context.Produtores.Remove(result);
            _context.SaveChanges();
            //passar o produtor na view
            return RedirectToAction(nameof(Index));
        }
    }
}
