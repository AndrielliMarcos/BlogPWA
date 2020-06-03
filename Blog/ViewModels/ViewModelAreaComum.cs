using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public abstract class ViewModelAreaComum
    {
        public string Layout = "_Layout";
        public string TituloPagina { get; set; }
    }
}
