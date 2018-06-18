using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
   public class JogoRepository : RepositoryBase<Jogo>, IJogoRepository
    {
        public JogoRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CriarJogo(Jogo jogo)
        {
            jogo.Id = Guid.NewGuid();
            Create(jogo);
            Save();
        }

        public override Jogo GetRecordById(Guid id)
        {
            return FindByCondition(Jogo => Jogo.Id.Equals(id))
            .DefaultIfEmpty(new Jogo())
            .FirstOrDefault();
        }

        public IEnumerable<Jogo> ObterTodos()
        {
            return FindAll()
                           .OrderBy(ow => ow.Descricao);
        }
    }
}
