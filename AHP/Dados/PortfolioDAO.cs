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
            try
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
            catch (Exception ex)
            {

            }
        }
        
        public void Excluir(int id)
        {
            try
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
            catch (Exception ex)
            {

            }
        }

        public List<Portfolio> Listar()
        {
            List<Portfolio> list = new List<Portfolio>();
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "select * from Portfolio";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    db.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
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
            catch (Exception ex)
            {

            }
            return null;   
        }

        public void Alterar(Portfolio portfolio)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "update portfolio set descricao = @descricao where id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("id", portfolio.ID);
                    cmd.Parameters.AddWithValue("descricao", portfolio.Descricao);
                    db.Open();
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
