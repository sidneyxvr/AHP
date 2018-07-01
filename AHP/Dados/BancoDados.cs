using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Dados
{
    class BancoDados
    {
        // Connection's configuration:
        private static string connectionString = @"Server=localhost;Database=Portfolio;Uid=root;Pwd=admin123;sslmode=none";
        private static MySqlConnection connection;

        private BancoDados() { }

        public static MySqlConnection getConnection
        {
            get
            {
                connection = new MySqlConnection(connectionString);
                return connection;
            }
        }
    }
}
