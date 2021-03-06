﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensEditarViewModel : ViewModelAreaAdministrativa
    {
        public int IdPostagem { get; set; }

        public string NomePostagem { get; set; }

        public int IdCategoriaPostagem { get; set; }
        public int IdAutorPostagem { get; set; }

        public string Erro { get; set; }

        public ICollection<CategoriaAdminPostagens> Categorias { get; set; }
        public ICollection<AutorAdminPostagens> Autores { get; set; }


        public AdminPostagensEditarViewModel()
        {
            TituloPagina = "Editar Etiqueta: ";
            Categorias = new List<CategoriaAdminPostagens>();
            Autores = new List<AutorAdminPostagens>();
        }
    }
}
