using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminCategoriasListarViewModel : ViewModelAreaAdministrativa
    {
        public ICollection<CategoriaAdminCategorias> Categorias { get; set; }
        public AdminCategoriasListarViewModel()
        {
            TituloPagina = "Categorias - Administrador";

            Categorias = new List<CategoriaAdminCategorias>();
        }
    }
    public class CategoriaAdminCategorias
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }
}
