using AHP.Dados;
using AHP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Negocios
{
    class RelacaoAtividadeBLL
    {
        private PortfolioAtividadeDAO paDao;
        private RelacaoAtividadeDAO raDao;
        private int portfolioId;

        public RelacaoAtividadeBLL(int portfolioId)
        {
            paDao = new PortfolioAtividadeDAO();
            raDao = new RelacaoAtividadeDAO();
            this.portfolioId = portfolioId;
        }

        public List<Atividade> ListarAtividades(int portfolioId)
        {
            return paDao.ListarPorPortfolio(portfolioId);
        }

        public void Adicionar(RelacaoAtividade relacaoAtividade)
        {
            raDao.Adicionar(relacaoAtividade);
        }

        public List<RelacaoAtividade> ListarPorPortfolio(int portfolioId)
        {
            return raDao.ListarPorPortfolio(portfolioId);
        }

        public void Alterar(RelacaoAtividade relacaoAtividade)
        {
            raDao.Alterar(relacaoAtividade);
        }

        public bool Verificar(RelacaoAtividade relacaoAtividade)
        {
            return raDao.Verificar(relacaoAtividade);
        }
    }
}
