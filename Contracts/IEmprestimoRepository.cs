using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
   public interface IEmprestimoRepository : IRepositoryBase<Emprestimo>
    {
        IEnumerable<Emprestimo> ObterTodos(int usuario);

        void CriarEmprestimo(Emprestimo emprestimo);

        Emprestimo retornarEmprestimo(int id);

        void Excluir(int usuario);
    }
}
