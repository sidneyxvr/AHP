using AHP.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Dados
{
    class PortfolioDAO
    {
        public void Adicionar(Portfolio portfolio)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "insert into portfolio values (default, @descricao, now())";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("descricao", portfolio.Descricao);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
        
        public void Remover(string id)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "delete from portfolio where id = @id";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("id", id);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public List<Portfolio> Listar()
        {
            List<Portfolio> list = new List<Portfolio>();
            using (var db = BancoDados.getConnection)
            {
                string query = "select * from Portfolio";
                MySqlCommand cmd = new MySqlCommand(query, db);
                db.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    list.Add(new Portfolio()
                    {
                        ID = Convert.ToInt32(reader["id"].ToString()),
                        Descricao = reader["descricao"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["datacriacao"].ToString())
                    });
                }
                db.Close();
            }
            return list;
        }
    }
}
