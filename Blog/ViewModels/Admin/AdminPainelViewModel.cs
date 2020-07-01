using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminPainelViewModel : ViewModelAreaAdministrativa
    {
        public AdminPainelViewModel()
        {
            TituloPagina = "Painel - Administrador";
        }

        public int postagem_count { get; set; }
        public int autor_count { get; set; }
        public int categoria_count { get; set; }

    }
   
}
