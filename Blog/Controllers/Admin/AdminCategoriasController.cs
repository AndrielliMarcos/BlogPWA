using Blog.Models.Blog.Categoria;
using Blog.RequestModels.AdminCategorias;
using Blog.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Blog.ViewModels.Admin.AdminCategoriasListarViewModel;

namespace Blog.Controllers.Admin
{
    public class AdminCategoriasController : Controller
    {
        private readonly CategoriaOrmService _categoriaOrmService;

        public AdminCategoriasController(
            CategoriaOrmService categoriaOrmService
        )
        {
            _categoriaOrmService = categoriaOrmService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            AdminCategoriasListarViewModel model = new AdminCategoriasListarViewModel();

            
            var listaCategorias = _categoriaOrmService.ObterCategorias();

            
            foreach (var categoriaEntity in listaCategorias)
            {
                var categoriaAdminCategorias = new CategoriaAdminCategorias();
                categoriaAdminCategorias.Id = categoriaEntity.Id;
                categoriaAdminCategorias.Nome = categoriaEntity.Nome;
               

                model.Categorias.Add(categoriaAdminCategorias);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detalhar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            AdminCategoriasCriarViewModel model = new AdminCategoriasCriarViewModel();

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminCategoriasCriarRequestModel request)
        {
            var nome = request.Nome;

            try
            {
                _categoriaOrmService.CriarCategoria(nome);
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
            AdminCategoriasEditarViewModel model = new AdminCategoriasEditarViewModel();

            // Obter etiqueta a editar
            var categoriaAEditar = _categoriaOrmService.ObterCategoriaPorId(id);
            if (categoriaAEditar == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            model.Id = categoriaAEditar.Id;
            model.Nome = categoriaAEditar.Nome;
            
            model.TituloPagina += model.TituloPagina;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminCategoriasEditarRequestModel request)
        {
            var id = request.Id;
            var nome = request.Nome;

            try
            {
                _categoriaOrmService.EditarCategoria(id, nome);
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
            AdminCategoriasRemoverViewModel model = new AdminCategoriasRemoverViewModel();

            // Obter etiqueta a remover
            var categoriaARemover = _categoriaOrmService.ObterCategoriaPorId(id);
            if (categoriaARemover == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Alimentar o model com os dados da etiqueta a ser editada
            model.Id = categoriaARemover.Id;
            model.Nome = categoriaARemover.Nome;
            model.TituloPagina += model.Nome;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Remover(AdminCategoriasRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _categoriaOrmService.RemoverCategoria(id);
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
