using AHP.Dados;
using AHP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Negocios
{
    class CriterioBLL
    {
        private CriterioDAO dao;

        public CriterioBLL()
        {
            dao = new CriterioDAO();
        }

        public void Adicionar(Criterio criterio)
        {
            dao.Adicionar(criterio);
        }

        public void Excluir(int id)
        {
            dao.Excluir(id);
        }

        public List<Criterio> Listar()
        {
            return dao.Listar();
        }

        public void Alterar(Criterio criterio)
        {
            dao.Alterar(criterio);
        }
    }
}
