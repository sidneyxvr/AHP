using AHP.Dados;
using AHP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AHP.Negocios
{
    class AtividadeBLL
    {
        private AtividadeDAO dao;

        public AtividadeBLL()
        {
            dao = new AtividadeDAO();
        }

        public void Adicionar(Atividade atividade)
        {
            dao.Adicionar(atividade);
        }

        public void Excluir(int id)
        {
            dao.Excluir(id);
        }

        public List<Atividade> Listar()
        {
            return dao.Listar();
        }

        public void Alterar(Atividade atividade)
        {
            dao.Alterar(atividade);
        }
    }
}
