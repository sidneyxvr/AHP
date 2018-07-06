using AHP.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Dados
{
    class PortfolioAtividadeDAO
    {
        public void Adicionar(PortfolioAtividade portfolioAtividade)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "insert into portfolio_atividade values (@atividadeId, @portfolioId)";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("atividadeId", portfolioAtividade.Atividade.ID);
                    cmd.Parameters.AddWithValue("portfolioId", portfolioAtividade.Portfolio.ID);
                    db.Open();
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Excluir(PortfolioAtividade portfolioAtividade)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "delete from portfolio_atividade where atividade_id = @atividadeId and portfolio_id = @portfolioId";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("atividadeId", portfolioAtividade.Atividade.ID);
                    cmd.Parameters.AddWithValue("portfolioId", portfolioAtividade.Portfolio.ID);
                    db.Open();
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<Atividade> ListarPorPortfolio(int portfolioId)
        {
            try
            {
                List<Atividade> list = new List<Atividade>();
                using (var db = BancoDados.getConnection)
                {
                    string query = "select a.id as a_id, a.descricao as Atividade " +
                        "from portfolio_atividade pc " +
                        "join portfolio p on p.id = pc.portfolio_id " +
                        "join atividade a on a.id = pc.atividade_id " +
                        "where pc.portfolio_id = @portfolioId";

                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("portfolioId", portfolioId);
                    db.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Atividade()
                        {
                            ID = Convert.ToInt32(reader["a_id"].ToString()),
                            Descricao = reader["atividade"].ToString()
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
