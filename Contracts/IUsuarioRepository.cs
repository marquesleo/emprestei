using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;


namespace Contracts
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario retornarUsuario(string login, string senha);

        void CriarUsuario(Usuario usuario);

       
    }
}
