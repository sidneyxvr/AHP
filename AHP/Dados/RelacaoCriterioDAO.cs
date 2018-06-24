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
        /*
        public void Excluir(int id)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "delete from atividade where id = @id";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("id", id);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
        */
        public List<RelacaoCriterio> ListarPorPortfolio(int portfolioId)
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
        /*
        public void Alterar(Atividade atividade)
        {
            using (var db = BancoDados.getConnection)
            {
                string query = "update atividade set descricao = @descricao where id = @id";
                MySqlCommand cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("id", atividade.ID);
                cmd.Parameters.AddWithValue("descricao", atividade.Descricao);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
        */
    }
}
