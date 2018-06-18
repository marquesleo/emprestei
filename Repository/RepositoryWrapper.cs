using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;

        private IJogoRepository _Jogo;

        private IAmigoRepository _Amigo;

        private IEmprestimoRepository _Emprestimo;

        private IUsuarioRepository _usuario;

        public IJogoRepository Jogo
        {
            get
            {
                if (_Jogo == null)
                    _Jogo = new JogoRepository(_repoContext);
                return _Jogo;
            }
        }

        public IAmigoRepository Amigo
        {
            get
            {
                if (_Amigo == null)
                    _Amigo = new AmigoRepository(_repoContext);
                return _Amigo;
            }
        }

        public IEmprestimoRepository Emprestimo
        {
            get
            {
                if (_Emprestimo == null)
                    _Emprestimo = new EmprestimoRepository(_repoContext);
                return _Emprestimo;
                        
            }
        }

        public IUsuarioRepository Usuario
        {
            get
            {
                if (_usuario == null)
                    _usuario = new UsuarioRepository(_repoContext);
                return _usuario;

            }
        }

    }
}

  

