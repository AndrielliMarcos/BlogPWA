using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminCategoriasRemoverViewModel : ViewModelAreaAdministrativa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Erro { get; set; }

        public AdminCategoriasRemoverViewModel()
        {
            TituloPagina = "Remover Categorias: ";
        }
    }
}
