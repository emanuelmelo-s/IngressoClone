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
    public class AtoresController : Controller
    {
        private IngressoDbContext _context;

        public AtoresController(IngressoDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.Atores);
        }

        public IActionResult Detalhes(int id)
        {
            var result = _context.Atores.Find(id);
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
            Ator ator = new Ator(atorDto.Nome, atorDto.Bio, atorDto.FotoPerfilURL);
            //instanciar um novo ator que receba os dados
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
