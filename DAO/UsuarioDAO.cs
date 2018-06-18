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
    public class UsuarioDAO : BaseDAO<Usuario>, IUsuarioRepository
    {
       protected override string nomeTabela => "usuario";
       protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0} (login,senha) " +
                    "VALUES(@login,@senha)", nomeTabela);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("UPDATE {0} SET USUARIO={1}USUARIO, " +
              "EMAIL={1}EMAIL,WWW={1}WWW, OBS={1}OBS, SENHA={1}SENHA " +
              "WHERE CODIGO={1}CODIGO", nomeTabela, "@");
            }
        }
        public UsuarioDAO(IConfiguration configuration) : base(configuration)
        {

        }
     

        public IEnumerable<Usuario> GetAllUsuario()
        {
            return this.FindAll();
        }



        public Usuario GetUsuarioById(int id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    return conexao.QueryFirst<Usuario>(string.Format("select  * from {0} where id={1}id ", nomeTabela, caracter), new { id = id });
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public void UpdateSenha(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    conexao.Execute(sqlUpdate, usuario);
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public Usuario retornarUsuario(string login, string senha)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    return conexao.QueryFirstOrDefault<Usuario>(string.Format("select  * from {0} where login=@login and senha=@senha ", nomeTabela), new { login = login, senha=senha });
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public void CriarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                {
                    conexao.Execute(sqlInsert,usuario);
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}

