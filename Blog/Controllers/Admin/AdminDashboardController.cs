using Blog.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers.Admin
{
    public class AdminDashboardController : Controller
    {
        //private readonly DatabaseContext _databaseContext;

        private DatabaseContext _databaseContext = new DatabaseContext();
        public IActionResult Index()
        {      

            AdminPainelViewModel dashboard = new AdminPainelViewModel();

            dashboard.postagem_count  = _databaseContext.Postagens.Count();
            dashboard.autor_count     = _databaseContext.Autores.Count();
            dashboard.categoria_count = _databaseContext.Categorias.Count();

            return View(dashboard);
        }
    }
}
