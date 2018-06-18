using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using DAO;

namespace RepositoryDapper
{
   public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {

        private UsuarioDAO UsuarioDAO;

        public UsuarioRepository(IConfiguration configuration)
       : base(configuration)
        {
            UsuarioDAO = new DAO.UsuarioDAO(configuration);
        }

        public void CriarUsuario(Usuario usuario)
        {
            UsuarioDAO.CriarUsuario(usuario);
        }

        public Usuario retornarUsuario(string login, string senha)
        {
            return UsuarioDAO.retornarUsuario(login, senha);
        }
    }
}
