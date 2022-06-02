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
            Produtor produtor = new Produtor(produtorDTO.Nome, produtorDTO.Bio,produtorDTO.FotoPerfilURL);

            _context.Produtores.Add(produtor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Atualizar()
        {
            //buscar o produtor no banco
            //passar o produtor  na view
            return View();
        }

        public IActionResult Deletar()
        {   //buscar o produtor no banco
            //passar o produtor na view
            return View();
        }
    }
}
