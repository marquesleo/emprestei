using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
      
        IAmigoRepository Amigo { get; }
        IUsuarioRepository Usuario { get; }

        IJogoRepository Jogo { get; }
        IEmprestimoRepository Emprestimo { get; }
    }
}
