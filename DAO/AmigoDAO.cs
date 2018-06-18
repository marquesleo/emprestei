using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections;
using Entities.Models;
using System.Collections.Generic;
using Contracts;
using System;
using System.Linq.Expressions;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAO
{
    public class AmigoDAO : BaseDAO<Amigo>, IAmigoRepository
    {
        public AmigoDAO(IConfiguration configuration) : base(configuration)
        {

        }
        protected override string nomeTabela => "amigo";
        protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0} (nome,usuario) " +
                    "VALUES(@nome,@usuario)", nomeTabela);
            }
        }

        public void CriarAmigo(Amigo amigo)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    conexao.Execute(sqlInsert, amigo);
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    conexao.Execute("delete from  " + nomeTabela + " where id=@id ", new { id = id });
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Amigo> ObterTodos(int usuario)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    return conexao.Query<Amigo>(string.Format("select * from {0} where usuario=@usuario", nomeTabela), new { usuario = usuario });
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public Amigo retornarAmigo(int id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    return conexao.QuerySingle<Amigo>("select * from " + nomeTabela + " where id=@id", new { id = id });
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
