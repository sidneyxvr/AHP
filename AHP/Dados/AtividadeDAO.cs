﻿using AHP.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Dados
{
    class AtividadeDAO
    {
        public void Adicionar(Atividade atividade)
        {
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "insert into atividade values (default, @descricao)";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    cmd.Parameters.AddWithValue("descricao", atividade.Descricao);
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
                    string query = "delete from atividade where id = @id";
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

        public List<Atividade> Listar()
        {
            List<Atividade> list = new List<Atividade>();
            try
            {
                using (var db = BancoDados.getConnection)
                {
                    string query = "select * from Atividade";
                    MySqlCommand cmd = new MySqlCommand(query, db);
                    db.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Atividade()
                        {
                            ID = Convert.ToInt32(reader["id"].ToString()),
                            Descricao = reader["descricao"].ToString()
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

        public void Alterar(Atividade atividade)
        {
            try
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
            catch(Exception ex)
            {

            }
        }
    }
}
