using AHP.Dados;
using AHP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Negocios
{
    class PortfolioCriterioBLL
    {
        private PortfolioCriterioDAO pcDao;
        private CriterioDAO cDao;
        private RelacaoCriterioDAO rcDao;

        public PortfolioCriterioBLL()
        {
            pcDao = new PortfolioCriterioDAO();
            cDao = new CriterioDAO();
            rcDao = new RelacaoCriterioDAO();
        }

        public void Adicionar(PortfolioCriterio portfolioCriterio)
        {
            pcDao.Adicionar(portfolioCriterio);
        }

        public void Excluir(PortfolioCriterio portfolioCriterio)
        {
            pcDao.Excluir(portfolioCriterio);
        }

        public List<Criterio> ListarPorPortfolio(int portfolioId)
        {
            return pcDao.ListarPorPortfolio(portfolioId);
        }
        
        public List<Tuple<Criterio, bool>> Listar(int portfolioId)
        {
            List<Criterio> todosCriterios = cDao.Listar();
            List<Criterio> noPortfolio = this.ListarPorPortfolio(portfolioId);
            List<Tuple<Criterio, bool>> result = new List<Tuple<Criterio, bool>>();
            foreach(var s in todosCriterios)
            {
                result.Add(new Tuple<Criterio, bool>(s, noPortfolio.Select(i => i.Descricao).Contains(s.Descricao) ? true: false));
            }
            return result.OrderBy(i => i.Item1.Descricao).ToList();
        }

        public void AdicionarRelacaoCriterioPortfolio(RelacaoCriterio relacaoCriterio)
        {
            rcDao.Adicionar(relacaoCriterio);
        }

        public void ExcluirRelacaoCriterioPortfolio(RelacaoCriterio relacaoCriterio)
        {
            rcDao.Excluir(relacaoCriterio);
        }

        public void ExcluirPorCriterio(RelacaoCriterio relacaoCriterio)
        {
            rcDao.ExcluirPorCriterio(relacaoCriterio);
        }
    }
}
