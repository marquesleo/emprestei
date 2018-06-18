using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AmigoRepository : RepositoryBase<Amigo>, IAmigoRepository
    {
        public AmigoRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {
        }

        public void CriarAmigo(Amigo amigo)
        {
            amigo.Id = Guid.NewGuid();
            Create(amigo);
            Save();
        }

        public override Amigo GetRecordById(Guid id)
        {
            return FindByCondition(Amigo => Amigo.Id.Equals(id))
             .DefaultIfEmpty(new Amigo())
            .FirstOrDefault();

        }

        public IEnumerable<Amigo> ObterTodos()
        {
            return FindAll()
                .OrderBy(ow => ow.Nome);
        }
    }
}
