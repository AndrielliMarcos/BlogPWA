using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminAutoresRemoverViewModel : ViewModelAreaAdministrativa
    {
        public int IdAutor { get; set; }

        public string NomeAutor { get; set; }

        public string Erro { get; set; }

        public AdminAutoresRemoverViewModel()
        {
            TituloPagina = "Remover Autor: ";
        }
    }
}
