using AHP.Dados;
using AHP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Negocios
{
    class PortfolioAtividadeBLL
    {
        private PortfolioAtividadeDAO paDao;
        private RelacaoAtividadeDAO raDao;
        private AtividadeDAO aDao;

        public PortfolioAtividadeBLL()
        {
            paDao = new PortfolioAtividadeDAO();
            raDao = new RelacaoAtividadeDAO();
            aDao = new AtividadeDAO();
        }

        public void Adicionar(PortfolioAtividade portfolioAtividade)
        {
            paDao.Adicionar(portfolioAtividade);
        }

        public void Excluir(PortfolioAtividade portfolioAtividade)
        {
            paDao.Excluir(portfolioAtividade);
        }

        public List<Atividade> ListarPorPortfolio(int portfolioId)
        {
            return paDao.ListarPorPortfolio(portfolioId);
        }

        public List<Tuple<Atividade, bool>> Listar(int portfolioId)
        {
            List<Atividade> todosAtividades = aDao.Listar();
            List<Atividade> noPortfolio = this.ListarPorPortfolio(portfolioId);
            List<Tuple<Atividade, bool>> result = new List<Tuple<Atividade, bool>>();
            foreach (var s in todosAtividades)
            {
                result.Add(new Tuple<Atividade, bool>(s, noPortfolio.Select(i => i.Descricao).Contains(s.Descricao) ? true : false));
            }
            return result.OrderBy(i => i.Item1.Descricao).ToList();
        }

        public void AdicionarRelacaoAtividadePortfolio(RelacaoAtividade relacaoAtividade)
        {
            raDao.Adicionar(relacaoAtividade);
        }

        public void ExcluirRelacaoAtividadePortfolio(RelacaoAtividade relacaoAtividade)
        {
            raDao.Excluir(relacaoAtividade);
        }
    }
}
