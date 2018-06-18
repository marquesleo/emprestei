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
    public class EmprestimoDAO : BaseDAO<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoDAO(IConfiguration configuration) : base(configuration)
        {

        }

        protected override string nomeTabela => "emprestimo";
        protected override string sqlInsert
         {
            get
            {
                 return string.Format("insert into {0} (Emprestado,Jogo,Amigo,Usuario) " +
                  "VALUES(@Emprestado,@Jogo,@Amigo,@Usuario)", nomeTabela);
            }
         }

        public void CriarEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    conexao.Execute(sqlInsert, emprestimo);
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void Excluir(int usuario)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    conexao.Execute("delete from  " + nomeTabela + " where usuario=@usuario ", new { usuario = usuario });
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Emprestimo> ObterTodos(int usuario)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    return conexao.Query<Emprestimo>(string.Format("select * from {0} where usuario=@usuario", nomeTabela), new { usuario = usuario });
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public Emprestimo retornarEmprestimo(int id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    return conexao.QuerySingle<Emprestimo>("select * from emprestimo where id=@id", new { id = id });
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
