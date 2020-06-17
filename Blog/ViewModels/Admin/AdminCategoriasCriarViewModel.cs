using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminCategoriasCriarViewModel : ViewModelAreaAdministrativa
    {
        public string Erro { get; set; }

        public AdminCategoriasCriarViewModel()
        {
            TituloPagina = "Criar nova Categoria";
           
        }
    }
    
}

