using AHP.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Dados
{
    class RelacaoAtividadeDAO
    {
        public void Adicionar(RelacaoAtividade relacaoAtividade)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "insert into rel_atividade values (@atividadeId1, @atividadeId2, @criterioId ,@nota, @portfolioId)";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("atividadeId1", relacaoAtividade.Atividade1.ID);
                cmd.Parameters.AddWithValue("atividadeId2", relacaoAtividade.Atividade2.ID);
                cmd.Parameters.AddWithValue("criterioId", relacaoAtividade.Criterio.ID);
                cmd.Parameters.AddWithValue("nota", relacaoAtividade.Nota);
                cmd.Parameters.AddWithValue("portfolioId", relacaoAtividade.Portfolio.ID);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public List<RelacaoAtividade> ListarPorPortfolio(int portfolioId)
        {
            List<RelacaoAtividade> list = new List<RelacaoAtividade>();
            using (var db = BancoDados.getConnection)
            {
                string query = 
                    "select a1.descricao as 'Atividade 1', " +
                    "a2.descricao as 'Atividade 2', " +
                    "c.descricao as Criterio, " +
                    "r.nota as Nota, p.descricao as Portfolio " +
                    "from rel_atividade r " +
                    "join atividade a1 on a1.id = r.atividade_id1 " +
                    "join atividade a2 on a2.id = r.atividade_id2 " +
                    "join portfolio p on p.id = r.portfolio_id " +
                    "join criterio c on c.id = r.criterio_id " +
                    "where r.portfolio_id = @portfolioId";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("portfolioId", portfolioId);
                db.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new RelacaoAtividade()
                    {
                        Atividade1 = new Atividade()
                        {
                            Descricao = reader["atividade 1"].ToString()
                        },
                        Atividade2 = new Atividade()
                        {
                            Descricao = reader["atividade 2"].ToString()
                        },
                        Criterio = new Criterio()
                        {
                            Descricao = reader["criterio"].ToString()
                        },
                        Nota = Convert.ToDouble(reader["nota"].ToString()),
                        Portfolio = new Portfolio()
                        {
                            Descricao = reader["portfolio"].ToString()
                        }
                    });
                }
                db.Close();
            }
            return list;
        }

        public void Alterar(RelacaoAtividade relacaoAtividade)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "update rel_atividade set nota = @nota where atividade_id1 = @atividadeId1 and " +
                                "atividade_id2 = @atividadeId2 and portfolio_id = @portfolioId and criterio_id = @criterioId";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("atividadeId1", relacaoAtividade.Atividade1.ID);
                cmd.Parameters.AddWithValue("atividadeId2", relacaoAtividade.Atividade2.ID);
                cmd.Parameters.AddWithValue("criterioId", relacaoAtividade.Criterio.ID);
                cmd.Parameters.AddWithValue("nota", relacaoAtividade.Nota);
                cmd.Parameters.AddWithValue("portfolioId", relacaoAtividade.Portfolio.ID);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public bool Verificar(RelacaoAtividade relacaoAtividade)
        {
            using (var db = BancoDados.getConnection)
            {
                string query =
                    "select * from rel_atividade where atividade_id1 = @atividadeId1 " +
                    "and atividade_id2 = @atividadeId2 and criterio_id = @criterioId " +
                    "and portfolio_id = @portfolioId";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("atividadeId1", relacaoAtividade.Atividade1.ID);
                cmd.Parameters.AddWithValue("atividadeId2", relacaoAtividade.Atividade2.ID);
                cmd.Parameters.AddWithValue("criterioId", relacaoAtividade.Criterio.ID);
                cmd.Parameters.AddWithValue("portfolioId", relacaoAtividade.Portfolio.ID);
                db.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                bool b = reader.Read();
                db.Close();
                return b;
            }
        }

        public void ExcluirPorAtividade(RelacaoAtividade relacaoAtividade)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "delete from rel_atividade where (atividade_id1 = @atividadeId or " +
                               "atividade_id2 = @atividadeId) and portfolio_id = @portfolioId";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("atividadeId", relacaoAtividade.Atividade1.ID);
                cmd.Parameters.AddWithValue("portfolioId", relacaoAtividade.Portfolio.ID);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
