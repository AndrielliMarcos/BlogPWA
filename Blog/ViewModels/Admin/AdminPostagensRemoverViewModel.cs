using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensRemoverViewModel : ViewModelAreaAdministrativa
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Erro { get; set; }

        public AdminPostagensRemoverViewModel()
        {
            TituloPagina = "Remover Postagens: ";
        }
    }
}
