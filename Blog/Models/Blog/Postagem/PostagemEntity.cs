using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem.Classificacao;
using Blog.Models.Blog.Postagem.Comentario;
using Blog.Models.Blog.Postagem.Revisao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string Titulo { get; set; }

        [MaxLength(640)]
        [Required]
        public string Descricao { get; set; }

        public AutorEntity Autor { get; set; }

        public CategoriaEntity Categoria { get; set; }

        public List<PostagemEtiquetaEntity> PostagensEtiquetas { get; set; }

        public ICollection<RevisaoEntity> Revisoes { get; set; }

        public ICollection<ComentarioEntity> Comentarios { get; set; }

        public ICollection<ClassificacaoEntity> Classificacoes { get; set; }
        public DateTime DataPublicacao { get; set; }


        public PostagemEntity()
        {
            PostagensEtiquetas = new List<PostagemEtiquetaEntity>();
            Revisoes = new List<RevisaoEntity>();
            Comentarios = new List<ComentarioEntity>();
            Classificacoes = new List<ClassificacaoEntity>();
        }
    }
}
