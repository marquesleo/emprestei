using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Repository
{
    public class EmprestimoRepository : RepositoryBase<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CriarEmprestimo(Emprestimo emprestimo)
        {
            emprestimo.Id = Guid.NewGuid();
            Create(emprestimo);
            Save();
        }

        public override Emprestimo GetRecordById(Guid id)
        {
            return FindByCondition(Emprestimo => Emprestimo.Id.Equals(id))
            .DefaultIfEmpty(new Emprestimo())
            .FirstOrDefault();
        }

        public IEnumerable<Emprestimo> ObterTodos()
        {
            return FindAll();
                 
        }
    }
}
