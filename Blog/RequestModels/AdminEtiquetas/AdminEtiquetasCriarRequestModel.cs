using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.RequestModels.AdminEtiquetas
{
    public class AdminEtiquetasCriarRequestModel
    {
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
    }
}
