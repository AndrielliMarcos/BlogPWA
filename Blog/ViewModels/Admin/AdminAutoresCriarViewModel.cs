using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminAutoresCriarViewModel : ViewModelAreaAdministrativa
    {
        public string Erro { get; set; }

        public AdminAutoresCriarViewModel()
        {
            TituloPagina = "Criar Novo Autor";
            
        }

        public class AutorAdminAutores
        {
            public int Id { get; set; }
            public string Nome { get; set; }

        }
    }


}
