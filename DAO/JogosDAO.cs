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
     public  class JogosDAO : BaseDAO<Jogo>, IJogoRepository
    {
        public JogosDAO(IConfiguration configuration) : base(configuration)
        {

        }
        protected override string nomeTabela => "jogo";
        protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0} (descricao,usuario) " +
                    "VALUES(@descricao,@usuario)", nomeTabela);
            }
        }

        public void CriarJogo(Jogo jogo)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    conexao.Execute(sqlInsert, jogo);
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
                    conexao.Execute("delete from  " + nomeTabela + " where id=@id " , new { id = id });
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Jogo> ObterTodos(int usuario)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    return conexao.Query<Jogo>(string.Format("select * from {0} where usuario=@usuario", nomeTabela), new { usuario = usuario });
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public Jogo retornarJogo(int id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    return conexao.QuerySingle<Jogo>("select * from jogo where id=@id", new { id = id });
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
