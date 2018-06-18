using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using DAO;
using System.Data.SqlClient;

namespace RepositoryDapper
{
    public class JogoRepository : RepositoryBase<Jogo>, IJogoRepository
    {
        private JogosDAO jogoDAO;
               
        public JogoRepository(IConfiguration configuration)
       : base(configuration)
        {
            jogoDAO = new DAO.JogosDAO(configuration);
        }

        public void CriarJogo(Jogo jogo)
        {
            jogoDAO.CriarJogo(jogo);
        }

        public void Excluir(int id)
        {
            jogoDAO.Excluir(id);
        }

        public IEnumerable<Jogo> ObterTodos(int usuario)
        {
            return jogoDAO.ObterTodos(usuario);
        }

        public Jogo retornarJogo(int id)
        {
            return jogoDAO.retornarJogo(id);
        }
    }
}
