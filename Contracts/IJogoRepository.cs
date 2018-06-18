using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IJogoRepository : IRepositoryBase<Jogo>
    {

        IEnumerable<Jogo> ObterTodos(int usuario);
        void CriarJogo(Jogo jogo);

        Jogo retornarJogo(int id);

        void Excluir(int id);

    }
}
