using Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace DAO
{
   
      public class BaseDAO<T> : IRepositoryBase<T> where T : class
        {
            protected string conexao
            {
                get { return this.infConnection.conexao; }
            }
            protected infConnection infConnection { get; set; }

            protected virtual string nomeTabela
            {
                get
                {
                    return "";
                }
            }

            protected virtual string sqlInsert
            {
                get
                {
                    return "";
                }

            }

            protected virtual string caracter
            {
                get
                {
                    return ":";
                }
            }

            protected virtual string sqlUpdate
            {
                get
                {
                    return "";
                }
            }


            protected IConfiguration _configuration;
            public BaseDAO(IConfiguration configuration)
            {
                _configuration = configuration;
                infConnection = MyDB.getStringConn(this._configuration);


            }
            public void Create(T entity)
            {
               try
                 {
                   using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                     {
                    conexao.Execute(sqlInsert, new { T = entity });
                      }
                    }
                  catch (SqlException ex)
                  {

                throw ex;
                 }
            }

            public void Delete(T entity)
            {
                try
                {
                    Entities.Models.IEntity entidade = (Entities.Models.IEntity)entity;
                    using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                    {
                        conexao.Execute(string.Format("delete from {0} where id={1}id", nomeTabela, caracter), new { codigo = entidade.Id });
                    }
                }
                catch (SqlException ex)
                {

                    throw ex;
                }
            }

            public IEnumerable<T> FindAll()
            {
                try
                {
                    using (SqlConnection conexao = new SqlConnection(infConnection.conexao))
                    {
                        return conexao.Query<T>(string.Format("select * from {0}", nomeTabela));
                    }
                }
                catch (SqlException ex)
                {

                    throw ex;
                }

            }

            public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
            {
                throw new NotImplementedException();
            }

            public void Save()
            {
                throw new NotImplementedException();
            }

            public void Update(T entity)
            {
                throw new NotImplementedException();
            }

       
    }
}
