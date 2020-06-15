using Blog.Models.Blog.Autor;
using Blog.RequestModels.AdminAutores;
using Blog.RequestModels.AdminCategorias;
using Blog.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Blog.Controllers.Admin
{
    public class AdminAutoresController : Controller
    {
        private readonly AutorOrmService _autorOrmService;

        public AdminAutoresController(
            AutorOrmService autorOrmService
        )
        {
            _autorOrmService = autorOrmService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            AdminAutoresListarViewModel model = new AdminAutoresListarViewModel();

            // Obter Autores
            var listaAutores = _autorOrmService.ObterAutores();

            // Alimentar o model com autores listados
            foreach (var autorEntity in listaAutores)
            {
                var autorAdminAutores = new AutorAdminAutores();
                autorAdminAutores.Id = autorEntity.Id;
                autorAdminAutores.Nome = autorEntity.Nome;
                
                model.Autores.Add(autorAdminAutores);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detalhar(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            AdminAutoresCriarViewModel model = new AdminAutoresCriarViewModel();

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

           return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminAutoresCriarRequestModel request)
        {
            var nome = request.Nome;

            try
            {
                _autorOrmService.CriarAutor(nome);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Criar");
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            AdminAutoresEditarViewModel model = new AdminAutoresEditarViewModel();

            // Obter etiqueta a editar
            var autorAEditar = _autorOrmService.ObterAutorPorId(id);
            if (autorAEditar == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Alimentar o model com os dados 
            model.IdAutor = autorAEditar.Id;
            model.NomeAutor = autorAEditar.Nome;            
            model.TituloPagina += model.NomeAutor;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminAutoresEditarRequestModel request)
        {
            var id = request.Id;
            var nome = request.Nome;

            try
            {
                _autorOrmService.EditarAutor(id, nome);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Editar", new { id = id });
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Remover(int id)
        {
            AdminAutoresRemoverViewModel model = new AdminAutoresRemoverViewModel();

            // Obter autor a remover
            var autorARemover = _autorOrmService.ObterAutorPorId(id);
            if (autorARemover == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Alimentar o model 
            model.IdAutor = autorARemover.Id;
            model.NomeAutor = autorARemover.Nome;
            model.TituloPagina += model.NomeAutor;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Remover(AdminAutoresCriarRequestModel request)
        {
            var id = request.Id;

            try
            {
                _autorOrmService.RemoverAutor(id);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Remover", new { id = id });
            }

            return RedirectToAction("Listar");
        }
    }
}
