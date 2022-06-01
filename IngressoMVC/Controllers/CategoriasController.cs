﻿using IngressoMVC.Data;
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





