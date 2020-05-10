using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.RequestModels.AdminPostagens
{
    public class AdminPostagensCriarRequestModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public DateTime DataPublicacao { get; set; }

        public AutorEntity Autor { get; set; }
        public CategoriaEntity Categoria { get; set; }
    }
}
