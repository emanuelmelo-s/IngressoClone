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
    public class CategoriasController : Controller
    {
        private IngressoDbContext _context;

        public CategoriasController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Categorias);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(PostCategoriaDTO categoriaDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoriaDto);
            }
            //receber os dados
            //validar os dados
            Categoria categoria = new Categoria(categoriaDto.Nome);
            //instanciar um novo ator que receba os dados
            //gravar o ator no banco de dados e salvar as mudanças
            _context.Categorias.Add(categoria);

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





