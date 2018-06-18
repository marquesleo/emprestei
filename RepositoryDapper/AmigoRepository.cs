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
    public class AmigoRepository : RepositoryBase<Amigo>, IAmigoRepository
    {
        private AmigoDAO amigoDAO;

        public AmigoRepository(IConfiguration configuration)
       : base(configuration)
        {
            amigoDAO = new DAO.AmigoDAO(configuration);
        }

        public void CriarAmigo(Amigo amigo)
        {
            amigoDAO.CriarAmigo(amigo);
        }

        public void Excluir(int id)
        {
            amigoDAO.Excluir(id);
        }

        public IEnumerable<Amigo> ObterTodos(int usuario)
        {
            return amigoDAO.ObterTodos(usuario);
        }

        public Amigo retornarAmigo(int id)
        {
            return amigoDAO.retornarAmigo(id);
        }
    }
}
