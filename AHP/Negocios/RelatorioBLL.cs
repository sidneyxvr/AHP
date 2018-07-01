using AHP.Dados;
using AHP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Negocios
{
    class RelatorioBLL
    {
        public double[,] MatrizCriterios { get; set; }
        public double[,,] MatrizAtividades { get; set; }
        private List<Criterio> criterios;
        private List<Atividade> atividades;
        private PortfolioCriterioDAO pcDao;
        private PortfolioAtividadeDAO paDao;
        private RelacaoCriterioDAO rcDao;
        private RelacaoAtividadeDAO raDao;
        private List<RelacaoCriterio> relacaoCriterios;
        private List<RelacaoAtividade> relacaoAtividades;
        private int portfolioId;

        public RelatorioBLL(int portfolioId)
        {
            this.portfolioId = portfolioId;
            pcDao = new PortfolioCriterioDAO();
            paDao = new PortfolioAtividadeDAO();
            rcDao = new RelacaoCriterioDAO();
            raDao = new RelacaoAtividadeDAO();
            preencherMatriz();
        }

        public void preencherMatriz()
        {
            criterios = pcDao.ListarPorPortfolio(portfolioId).OrderBy(i => i.Descricao).ToList();
            relacaoCriterios = rcDao.ListarPorPortfolio(portfolioId);
            MatrizCriterios = new double[criterios.Count, criterios.Count];
            foreach(var obj in relacaoCriterios)
            {
                int c = criterios.FindIndex(i => i.Descricao == obj.Criterio1.Descricao);
                int l = criterios.FindIndex(i => i.Descricao == obj.Criterio2.Descricao);
                MatrizCriterios[l, c] = obj.Nota;
                MatrizCriterios[c, l] = Double.IsInfinity(1 / obj.Nota) ? 0 : 1 / obj.Nota;
            }
            atividades = paDao.ListarPorPortfolio(portfolioId).OrderBy(i => i.Descricao).ToList();
            relacaoAtividades = raDao.ListarPorPortfolio(portfolioId);
            MatrizAtividades = new double[atividades.Count, atividades.Count, criterios.Count];
            foreach(var obj in relacaoAtividades)
            {
                int c = atividades.FindIndex(i => i.Descricao == obj.Atividade1.Descricao);
                int l = atividades.FindIndex(i => i.Descricao == obj.Atividade2.Descricao);
                int d = criterios.FindIndex(i => i.Descricao == obj.Criterio.Descricao);
                MatrizAtividades[l, c, d] = obj.Nota;
                MatrizAtividades[c, l, d] = Double.IsInfinity(1 / obj.Nota) ? 0: 1 / obj.Nota;
            }
        }
    }
}
