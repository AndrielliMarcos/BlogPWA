using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Autor
{
    public class AutorOrmService
    {
        private readonly DatabaseContext _databaseContext;
        public AutorOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<AutorEntity> ObterAutores()
        {
            return _databaseContext.Autores.ToList();
        }

        public AutorEntity ObterAutorPorId(int idAutor)
        {
            var autor = _databaseContext.Autores.Find(idAutor);

            return autor;
        }

        public AutorEntity CriarAutor(string nome)
        {
            var novoAutor = new AutorEntity { Nome = nome };
            _databaseContext.Autores.Add(novoAutor);
            _databaseContext.SaveChanges();

            return novoAutor;
        }

        public AutorEntity EditarAutor(int id, string nome)
        {
            var autor = _databaseContext.Autores.Find(id);

            if (autor == null)
            {
                throw new Exception("Autor não encontrada!");
            }

            autor.Nome = nome;
            _databaseContext.SaveChanges();

            return autor;
        }

        public bool RemoverAutor(int id)
        {
            var autor = _databaseContext.Autores.Find(id);

            if (autor == null)
            {
                throw new Exception("Autor não encontrada!");
            }

            _databaseContext.Autores.Remove(autor);
            _databaseContext.SaveChanges();

            return true;
        }

    }
}
