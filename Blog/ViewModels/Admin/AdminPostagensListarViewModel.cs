using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensListarViewModel : ViewModelAreaAdministrativa
    {
        public ICollection<PostagemAdminPostagens> Postagens { get; set; }
        public AdminPostagensListarViewModel()
        {
            TituloPagina = "Postagens - Administrador";

            Postagens = new List<PostagemAdminPostagens>();
        }
    }

    public class PostagemAdminPostagens
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string NomeAutor { get; set; }
        public string NomeCategoria { get; set; }
        public DateTime DataPublicacao { get; set; }

    }
}
