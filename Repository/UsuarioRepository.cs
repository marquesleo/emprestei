using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(RepositoryContext repositoryContext)
     : base(repositoryContext)
        {
        }

        public void CriarUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            Create(usuario);
            Save();
        }

        public override Usuario GetRecordById(Guid id)
        {
            return FindByCondition(usuario => usuario.Id.Equals(id))
           .DefaultIfEmpty(new Usuario())
           .FirstOrDefault();
        }

        public Usuario retornarUsuario(string login, string senha)
        {
            return this.FindByCondition(p => p.login == login && p.senha == senha)
                  .DefaultIfEmpty(new Usuario())
                  .FirstOrDefault();

        }
    }
}
