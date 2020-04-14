using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Categoria
{
    public class CategoriaEntity
    {
        [Key] public int Id { get; set; }

        [MaxLength(128)] [Required] public string Nome { get; set; }

        public ICollection<PostagemEntity> Postagens { get; set; }

        public ICollection<EtiquetaEntity> Etiquetas { get; set; }


        public CategoriaEntity()
        {
            Postagens = new List<PostagemEntity>();
            Etiquetas = new List<EtiquetaEntity>();
        }
    }
}
