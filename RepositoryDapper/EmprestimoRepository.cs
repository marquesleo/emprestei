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
    public class EmprestimoRepository : RepositoryBase<Emprestimo>, IEmprestimoRepository
    {
        private EmprestimoDAO emprestimoDAO;

        public EmprestimoRepository(IConfiguration configuration)
       : base(configuration)
        {
            emprestimoDAO = new DAO.EmprestimoDAO(configuration);
        }

        public void CriarEmprestimo(Emprestimo emprestimo)
        {
            emprestimoDAO.CriarEmprestimo(emprestimo);
        }

        public void Excluir(int usuario)
        {
            emprestimoDAO.Excluir(usuario);
        }

        public IEnumerable<Emprestimo> ObterTodos(int usuario)
        {
            return emprestimoDAO.ObterTodos(usuario);
        }

        public Emprestimo retornarEmprestimo(int id)
        {
            return emprestimoDAO.retornarEmprestimo(id);
        }
    }
}
