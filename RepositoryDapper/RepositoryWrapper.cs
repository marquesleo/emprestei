using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Microsoft.Extensions.Configuration;


namespace RepositoryDapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IConfiguration _configuration;
        public RepositoryWrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
      
        private IUsuarioRepository _usuario;


        private IAmigoRepository _amigo;
        public IAmigoRepository Amigo
        {
            get
            {
                if (_amigo == null)
                    _amigo = new AmigoRepository(_configuration);
                return _amigo;
            }
        }


        private IEmprestimoRepository _Emprestimo;
        public IEmprestimoRepository Emprestimo
        {
            get
            {
                if (_Emprestimo == null)
                    _Emprestimo = new EmprestimoRepository(_configuration);
                return _Emprestimo;
            }
        }

        public IUsuarioRepository Usuario
        {
            get
            {
                if (_usuario == null)
                    _usuario = new UsuarioRepository(_configuration);
                return _usuario;
            }
        }

        private IJogoRepository _jogo;
        public IJogoRepository Jogo
        {
            get
            {
                if (_jogo == null)
                    _jogo = new JogoRepository(_configuration);
                return _jogo;
            }
        }
    }
}
