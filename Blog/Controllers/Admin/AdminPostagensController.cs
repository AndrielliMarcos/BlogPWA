using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem;
using Blog.RequestModels.AdminPostagens;
using Blog.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers.Admin
{
    public class AdminPostagensController : Controller
    {
        private readonly PostagemOrmService _postagemOrmService;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly AutorOrmService _autorOrmService;


        public AdminPostagensController(
            PostagemOrmService postagemOrmService,
            CategoriaOrmService categoriaOrmService,
            AutorOrmService autorOrmService
        )
        {
            _postagemOrmService = postagemOrmService;
            _categoriaOrmService = categoriaOrmService;
            _autorOrmService = autorOrmService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            AdminPostagensListarViewModel model = new AdminPostagensListarViewModel();

            var listaPostagens = _postagemOrmService.ObterPostagens();

            // Alimentar o model com as postagens que serão listadas
            foreach (var postagemEntity in listaPostagens)
            {
                var postagemAdminPostagens = new PostagemAdminPostagens();

                postagemAdminPostagens.Id = postagemEntity.Id;
                postagemAdminPostagens.Titulo = postagemEntity.Titulo;
                postagemAdminPostagens.Descricao = postagemEntity.Descricao;
                postagemAdminPostagens.NomeAutor = postagemEntity.Autor.Nome;
                postagemAdminPostagens.NomeCategoria = postagemEntity.Categoria.Nome;
                postagemAdminPostagens.DataPublicacao = postagemEntity.DataPublicacao;

                model.Postagens.Add(postagemAdminPostagens);
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
            AdminPostagensCriarViewModel model = new AdminPostagensCriarViewModel();

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Obter as Categorias
            var listaCategorias = _categoriaOrmService.ObterCategorias();

            // Alimentar o model com as categorias que serão colocadas no <select> do formulário
            foreach (var categoriaEntity in listaCategorias)
            {
                var categoriaAdminPostagens = new CategoriaAdminPostagens();
                categoriaAdminPostagens.IdCategoria = categoriaEntity.Id;
                categoriaAdminPostagens.NomeCategoria = categoriaEntity.Nome;

                model.Categorias.Add(categoriaAdminPostagens);
            }

            // Obter as Autores
            var listaAutores = _autorOrmService.ObterAutores();

            // Alimentar o model com os autores que serão colocadas no <select> do formulário
            foreach (var autorEntity in listaAutores)
            {
                var autorAdminPostagens = new AutorAdminPostagens();
                autorAdminPostagens.IdAutor = autorEntity.Id;
                autorAdminPostagens.NomeAutor = autorEntity.Nome;

                model.Autores.Add(autorAdminPostagens);
            }

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminPostagensCriarRequestModel request)
        {
            var titulo = request.Titulo;
            var descricao = request.Descricao;
            var autor = request.Autor;
            var categoria = request.Categoria;
            var dataPublicacao = request.DataPublicacao;


            try
            {
                _postagemOrmService.CriarPostagem(titulo, descricao, autor, categoria, dataPublicacao);
                
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
            AdminPostagensEditarViewModel model = new AdminPostagensEditarViewModel();

            var postagemAEditar = _postagemOrmService.ObterPostagemPorId(id);
            if (postagemAEditar == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Obter as Categorias
            var listaCategorias = _categoriaOrmService.ObterCategorias();

            // Alimentar o model com as categorias que serão colocadas no <select> do formulário
            foreach (var categoriaEntity in listaCategorias)
            {
                var categoriaAdminPostagens = new CategoriaAdminPostagens();
                categoriaAdminPostagens.IdCategoria = categoriaEntity.Id;
                categoriaAdminPostagens.NomeCategoria = categoriaEntity.Nome;

                model.Categorias.Add(categoriaAdminPostagens);
            }

            // Obter autores
            var listaAutores = _autorOrmService.ObterAutores();

            // Alimentar o model com autores
            foreach (var autorEntity in listaAutores)
            {
                var autorAdminPostagens = new AutorAdminPostagens();
                autorAdminPostagens.IdAutor = autorEntity.Id;
                autorAdminPostagens.NomeAutor= autorEntity.Nome;

                model.Autores.Add(autorAdminPostagens);
            }
      
            model.IdPostagem = postagemAEditar.Id;
            model.NomePostagem = postagemAEditar.Titulo;
            model.IdCategoriaPostagem = postagemAEditar.Categoria.Id;
            model.IdAutorPostagem = postagemAEditar.Autor.Id;
            model.TituloPagina += model.NomePostagem;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminPostagensEditarRequestModel request)
        {
            var id = request.Id;
            var titulo = request.Titulo;
            var descricao = request.Descricao;
            var autor = request.Autor;
            var categoria = request.Categoria;
            var dataPublicacao = request.DataPublicacao;

            try
            {
                _postagemOrmService.EditarPostagem(id, titulo, descricao, autor, categoria, dataPublicacao);
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
            AdminPostagensRemoverViewModel model = new AdminPostagensRemoverViewModel();

            var postagemARemover = _postagemOrmService.ObterPostagemPorId(id);
            if (postagemARemover == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

           
            model.Id = postagemARemover.Id;
            model.Titulo = postagemARemover.Titulo;
            model.TituloPagina += model.Titulo;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Remover(AdminPostagensRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _postagemOrmService.RemoverPostagem(id);
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
