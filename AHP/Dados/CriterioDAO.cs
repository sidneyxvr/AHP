using AHP.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Dados
{
    class CriterioDAO
    {
        public void Adicionar(Criterio criterio)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "insert into criterio values (default, @descricao)";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("descricao", criterio.Descricao);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void Excluir(int id)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "delete from criterio where id = @id";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("id", id);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public List<Criterio> Listar()
        {
            List<Criterio> list = new List<Criterio>();
            using (var db = BancoDados.getConnection)
            {
                string query = "select * from Criterio";
                MySqlCommand cmd = new MySqlCommand(query, db);
                db.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Criterio()
                    {
                        ID = Convert.ToInt32(reader["id"].ToString()),
                        Descricao = reader["descricao"].ToString(),
                    });
                }
                db.Close();
            }
            return list;
        }

        public void Alterar(Criterio criterio)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "update criterio set descricao = @descricao where id = @id";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("id", criterio.ID);
                cmd.Parameters.AddWithValue("descricao", criterio.Descricao);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
