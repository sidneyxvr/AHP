using AHP.Dados;
using AHP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Negocios
{
    class RelacaoCriterioBLL
    {
        private PortfolioCriterioDAO pcDao;
        private RelacaoCriterioDAO rcDao;
        private int portfolioId;

        public RelacaoCriterioBLL()
        {
            pcDao = new PortfolioCriterioDAO();
            rcDao = new RelacaoCriterioDAO();
        }
        
        public List<Criterio> ListarCriterios(int portfolioId)
        {
            return pcDao.ListarPorPortfolio(portfolioId);
        }

        public void Adicionar(RelacaoCriterio relacaoCriterio)
        {
            rcDao.Adicionar(relacaoCriterio);
        }

        public List<RelacaoCriterio> ListarPorPortfolio(int portfolioId)
        {
            return rcDao.ListarPorPortfolio(portfolioId);
        }

        public void Alterar(RelacaoCriterio relacaoCriterio)
        {
            rcDao.Alterar(relacaoCriterio);
        }

        public bool Verificar(RelacaoCriterio relacaoCriterio)
        {
            return rcDao.Verificar(relacaoCriterio);
        }
    }
}
