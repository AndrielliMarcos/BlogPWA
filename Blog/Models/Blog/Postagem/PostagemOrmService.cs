using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public PostagemOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PostagemEntity> ObterPostagens()
        {
            return _databaseContext.Postagens
                .Include(p => p.Categoria)
                .Include(p => p.Revisoes)
                .Include(p => p.Comentarios)
                .ToList();
        }

        public List<PostagemEntity> ObterPostagensPopulares()
        {
            return _databaseContext.Postagens
               .Where(c => c.Comentarios.Count > 0)
               .ToList();

            //COMO ORDENAR AS POSTAGENS PELO MAIOR NUMERO DE COMENTARIOS??
        }
    }
}
