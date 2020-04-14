using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Autor
{
    public class AutorEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string Nome { get; set; }
    }
}
