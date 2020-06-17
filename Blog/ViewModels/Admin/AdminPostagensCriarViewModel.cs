using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensCriarViewModel : ViewModelAreaAdministrativa
    {
        public string Erro { get; set; }

        public ICollection<CategoriaAdminPostagens> Categorias { get; set; }
        public ICollection<AutorAdminPostagens> Autores { get; set; }


        public AdminPostagensCriarViewModel()
        {
            TituloPagina = "Criar nova Postagem";

            Categorias = new List<CategoriaAdminPostagens>();

            Autores = new List<AutorAdminPostagens>();
        }
    }

    public class CategoriaAdminPostagens
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
    }

    public class AutorAdminPostagens
    {
        public int IdAutor { get; set; }
        public string NomeAutor { get; set; }
    }
}
