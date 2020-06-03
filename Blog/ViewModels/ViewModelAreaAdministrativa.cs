using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public abstract class ViewModelAreaAdministrativa
    {
        public string Layout = "_LayoutAdmin";
        public string TituloPagina { get; set; }
    }
}
