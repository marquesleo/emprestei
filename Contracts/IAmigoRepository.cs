using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IAmigoRepository : IRepositoryBase<Amigo>
    {
        IEnumerable<Amigo> ObterTodos(int usuario);

        void CriarAmigo(Amigo amigo);

        Amigo retornarAmigo(int id);

        void Excluir(int id);
    }
}
