using AHP.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Dados
{
    class PortfolioCriterioDAO
    {
        public void Adicionar(PortfolioCriterio portfolioCriterio)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "insert into portfolio_criterio values (@criterioId, @portfolioId)";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("criterioId", portfolioCriterio.Criterio.ID);
                    cmd.Parameters.AddWithValue("portfolioId", portfolioCriterio.Portfolio.ID);
                    db.Open();
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        public void Excluir(PortfolioCriterio portfolioCriterio)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "delete from portfolio_criterio where criterio_id = @criterioId and portfolio_id = @portfolioId";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("criterioId", portfolioCriterio.Criterio.ID);
                    cmd.Parameters.AddWithValue("portfolioId", portfolioCriterio.Portfolio.ID);
                    db.Open();
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        public List<Criterio> ListarPorPortfolio(int portfolioId)
        {
            List<Criterio> list = new List<Criterio>();
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "select c.id as c_id, c.descricao as Criterio " +
                        "from portfolio_criterio pc " +
                        "join portfolio p on p.id = pc.portfolio_id " +
                        "join criterio c on c.id = pc.criterio_id " +
                        "where pc.portfolio_id = @portfolioId";

                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("portfolioId", portfolioId);
                    db.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Criterio()
                        {
                            ID = Convert.ToInt32(reader["c_id"].ToString()),
                            Descricao = reader["criterio"].ToString()
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
    }
}
