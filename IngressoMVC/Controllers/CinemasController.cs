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
    public class CinemasController : Controller
    {
        private IngressoDbContext _context;

        public CinemasController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Cinemas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostCinemaDTO cinemaDTO)
        {
            Cinema cinema = new Cinema(cinemaDTO.Nome,cinemaDTO.Descricao,cinemaDTO.LogoURL);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Atualizar()
        {
            //buscar a categoria no banco
            //passar a categoria na view
            return View();
        }

        public IActionResult Deletar()
        {   //buscar a categoria no banco
            //passar a categoria na view
            return View();
        }
        
    }
}
