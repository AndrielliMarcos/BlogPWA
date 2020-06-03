using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public abstract class ViewModelControleDeAcesso
    {
        public string Layout = "_LayoutControleDeAcesso";
        public string TituloPagina { get; set; }
    }
}
