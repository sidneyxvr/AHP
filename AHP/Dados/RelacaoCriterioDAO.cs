using AHP.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Dados
{
    class RelacaoCriterioDAO
    {
        public void Adicionar(RelacaoCriterio relacaoCriterio)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "insert into rel_criterio values (@criterioId1, @criterioId2, @nota, @portfolioId)";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("criterioId1", relacaoCriterio.Criterio1.ID);
                    cmd.Parameters.AddWithValue("criterioId2", relacaoCriterio.Criterio2.ID);
                    cmd.Parameters.AddWithValue("nota", relacaoCriterio.Nota);
                    cmd.Parameters.AddWithValue("portfolioId", relacaoCriterio.Portfolio.ID);
                    db.Open();
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Excluir(RelacaoCriterio relacaoCriterio)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "delete from rel_criterio where criterio_id1 = @criterioId or " +
                                   "criterio_id2 = @criterioId and portfolio_id = @portfolioId";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("criterioId", relacaoCriterio.Criterio1.ID);
                    cmd.Parameters.AddWithValue("portfolioId", relacaoCriterio.Portfolio.ID);
                    db.Open();
                    cmd.ExecuteNonQuery();
                    db.Close();
                }

            }
            catch (Exception ex)
            {

            }
        }
        public List<RelacaoCriterio> ListarPorPortfolio(int portfolioId)
        {
            try
            {
                List<RelacaoCriterio> list = new List<RelacaoCriterio>();
                using (var db = BancoDados.getConnection)
                {
                    string query = "select c1.descricao as 'Criterio 1', c2.descricao as 'Criterio 2', " +
                        "r.nota as Nota, p.descricao as Portfolio from rel_criterio r " +
                        "join criterio c1 on c1.id = r.criterio_id1 " +
                        "join criterio c2 on c2.id = r.criterio_id2 " +
                        "join portfolio p on p.id = r.portfolio_id " +
                        "where r.portfolio_id = @portfolioId";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("portfolioId", portfolioId);
                    db.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new RelacaoCriterio()
                        {
                            Criterio1 = new Criterio()
                            {
                                Descricao = reader["criterio 1"].ToString()
                            },
                            Criterio2 = new Criterio()
                            {
                                Descricao = reader["criterio 2"].ToString()
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
            catch (Exception ex)
            {

            }
            return null;
        }
        
        public void Alterar(RelacaoCriterio relacaoCriterio)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "update rel_criterio set nota = @nota where criterio_id1 = @criterioId1 and " +
                                    "criterio_id2 = @criterioId2 and portfolio_id = @portfolioId";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("criterioId1", relacaoCriterio.Criterio1.ID);
                    cmd.Parameters.AddWithValue("criterioId2", relacaoCriterio.Criterio2.ID);
                    cmd.Parameters.AddWithValue("nota", relacaoCriterio.Nota);
                    cmd.Parameters.AddWithValue("portfolioId", relacaoCriterio.Portfolio.ID);
                    db.Open();
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        public RelacaoCriterio RelacaoPorCriterioPortfolio(RelacaoCriterio relacaoCriterio)
        {
            try
            {
                string query = "select c1.id as 'Criterio1', c2.id as 'Criterio2', " +
                   "r.nota as Nota, p.id as Portfolio from rel_criterio r " +
                   "join criterio c1 on c1.id = r.criterio_id1 " +
                   "join criterio c2 on c2.id = r.criterio_id2 " +
                   "join portfolio p on p.id = r.portfolio_id " +
                   "where r.portfolio_id = @portfolioId and " +
                   "r.criterio_id1 = @criterioId1 and " +
                   "r.criterio_id2 = @criterioId2";
                using (var db = BancoDados.getConnection)
                {
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("criterioId1", relacaoCriterio.Criterio1.ID);
                    cmd.Parameters.AddWithValue("criterioId2", relacaoCriterio.Criterio2.ID);
                    cmd.Parameters.AddWithValue("portfolioId", relacaoCriterio.Portfolio.ID);
                    db.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new RelacaoCriterio()
                        {
                            Criterio1 = new Criterio()
                            {
                                ID = Convert.ToInt32(reader["criterio1"])
                            },
                            Criterio2 = new Criterio()
                            {
                                ID = Convert.ToInt32(reader["criterio2"])
                            },
                            Nota = Convert.ToDouble(reader["nota"]),
                            Portfolio = new Portfolio()
                            {
                                ID = Convert.ToInt32(reader["portfolio"])
                            }
                        };
                    }
                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public bool Verificar(RelacaoCriterio relacaoCriterio)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query =
                        "select * from rel_criterio where criterio_id1 = @criterioId1 " +
                        "and criterio_id2 = @criterioId2 and portfolio_id = @portfolioId " +
                        "limit 1";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("criterioId1", relacaoCriterio.Criterio1.ID);
                    cmd.Parameters.AddWithValue("criterioId2", relacaoCriterio.Criterio2.ID);
                    cmd.Parameters.AddWithValue("portfolioId", relacaoCriterio.Portfolio.ID);
                    db.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    bool b = reader.Read();
                    db.Close();
                    return b;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public void ExcluirPorCriterio(RelacaoCriterio relacaoCriterio)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "delete from rel_criterio where portfolio_id = @portfolioId and " +
                                    "(criterio_id1 = @criterioId or criterio_id2 = @criterioId)";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("criterioId", relacaoCriterio.Criterio1.ID);
                    cmd.Parameters.AddWithValue("portfolioId", relacaoCriterio.Portfolio.ID);
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
