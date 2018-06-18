using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public class infConnection
    {
        public string conexao { get; set; }
        public string db { get; set; }
    }
    public static class MyDB
    {

        private static infConnection _infConnection { get; set; }
        public static infConnection getStringConn(IConfiguration config)
        {
            if (_infConnection == null)
            {

                _infConnection = new infConnection();


                _infConnection.conexao = config["sqlserver:connectionString"];
                _infConnection.db = config["conexao:db"];


            }

            return _infConnection;
        }
    }
}
