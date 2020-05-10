using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public PostagemOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PostagemEntity> ObterPostagens()
        {
            return _databaseContext.Postagens
                .Include(p => p.Categoria)
                .Include(p => p.Revisoes)
                .Include(p => p.Comentarios)
                //incluir a postagem na hora e data solicitada 
                .Where(p => p.DataPublicacao < DateTime.Now)
                .ToList();
        }

        public List<PostagemEntity> ObterPostagensPopulares()
        {
            return _databaseContext.Postagens
               .Where(c => c.Comentarios.Count > 0)
               .ToList();

            //DÚVIDA: COMO ORDENAR AS POSTAGENS PELO MAIOR NUMERO DE COMENTARIOS??
        }

        public PostagemEntity CriarPostagem(string titulo, string descricao, AutorEntity autor, CategoriaEntity categoria, DateTime dataPublicacao)
        {
            var novaPostagem = new PostagemEntity { Titulo = titulo, Descricao = descricao, Autor = autor, Categoria = categoria, DataPublicacao = dataPublicacao };
            _databaseContext.Postagens.Add(novaPostagem);
            _databaseContext.SaveChanges();

            return novaPostagem;
        }

        public PostagemEntity EditarPostagem(int id, string titulo, string descricao, AutorEntity autor, CategoriaEntity categoria, DateTime dataPublicacao)
        {
            var postagem = _databaseContext.Postagens.Find(id);

            if (postagem == null)
            {
                throw new Exception("Postagem não encontrada!");
            }

            postagem.Titulo = titulo;
            postagem.Descricao = descricao;
            postagem.Autor = autor;
            postagem.Categoria = categoria;
            postagem.DataPublicacao = dataPublicacao;
            _databaseContext.SaveChanges();

            return postagem;
        }

        public bool RemoverPostagem(int id)
        {
            var postagem = _databaseContext.Postagens.Find(id);

            if (postagem == null)
            {
                throw new Exception("Postagem não encontrada!");
            }

            _databaseContext.Postagens.Remove(postagem);
            _databaseContext.SaveChanges();

            return true;
        }
       
    }
}
