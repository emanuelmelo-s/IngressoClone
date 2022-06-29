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
        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return View();
            //buscar a categoria no banco
            var result = _context.Categorias.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View();
            //passar a categoria na view
            return View();
        }

        [HttpPost]
        public IActionResult Atualizar (int id,PostCategoriaDTO categoriaDTO)
        {
            var categoria = _context.Categorias.FirstOrDefault(a => a.Id == id);

            categoria.AtualizaCategoria(categoriaDTO.Nome);
            _context.Categorias.Update(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int? id)
        {
            if (id == null)
                return View();
            //buscar a categoria no banco
            var result = _context.Categorias.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View();
            //passar a categoria na view
            return View(result);
        }

        [HttpPost]
        public IActionResult ConfirmarDeletar(int id)
        {   //buscar a categoria no banco
            var categoria = _context.Categorias.FirstOrDefault(a => a.Id == id);
            
            if (categoria == null)
                return View();

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            //passar a categoria na view
            return RedirectToAction(nameof(Index));
        }
    }
}





