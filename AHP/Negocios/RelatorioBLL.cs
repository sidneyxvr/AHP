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
        public List<double> vetEigenCriterios;
        // public List<List<double>> vetEigenAtividades;
        public double[,] vetEigenAtividades { get; set; }
        public List<double> listaRelatorio;
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
            vetEigenCriterios = new List<double>();
            //vetEigenAtividades = new List<List<double>>();
            listaRelatorio = new List<double>();
            preencherMatrizCriterios();
            preencherListaCriterios();
            preencherMatrizAtividades();
            preencherListaAtividades();
            gerarRelatorio();
        }

        public void preencherMatrizCriterios()
        {
            criterios = pcDao.ListarPorPortfolio(portfolioId).OrderBy(i => i.Descricao).ToList();
            relacaoCriterios = rcDao.ListarPorPortfolio(portfolioId);
            MatrizCriterios = new double[criterios.Count, criterios.Count];
            foreach (var obj in relacaoCriterios)
            {
                int c = criterios.FindIndex(i => i.Descricao == obj.Criterio1.Descricao);
                int l = criterios.FindIndex(i => i.Descricao == obj.Criterio2.Descricao);
                MatrizCriterios[l, c] = obj.Nota;
                MatrizCriterios[c, l] = Double.IsInfinity(1 / obj.Nota) ? 0 : 1 / obj.Nota;
            }

            for (int i = 0; i < criterios.Count; i++)
            {
                double somaColuna = 0;
                int j;
                for (j = 0; j < criterios.Count; j++)
                {
                    somaColuna += MatrizCriterios[j, i];
                }

                for (j = 0; j < criterios.Count; j++)
                {
                    MatrizCriterios[j, i] /= somaColuna;
                }
            }
        }

        public void preencherListaCriterios()
        {
            for (int i = 0; i < criterios.Count; i++)
            {
                double soma = 0;
                for (int j = 0; j < criterios.Count; j++)
                {
                    soma += MatrizCriterios[i, j];
                }
                vetEigenCriterios.Add(soma / criterios.Count);
            }
        }

        public void preencherMatrizAtividades()
        {
            atividades = paDao.ListarPorPortfolio(portfolioId).OrderBy(i => i.Descricao).ToList();
            relacaoAtividades = raDao.ListarPorPortfolio(portfolioId);
            MatrizAtividades = new double[atividades.Count, atividades.Count, criterios.Count];
            foreach (var obj in relacaoAtividades)
            {
                int c = atividades.FindIndex(i => i.Descricao == obj.Atividade1.Descricao);
                int l = atividades.FindIndex(i => i.Descricao == obj.Atividade2.Descricao);
                int d = criterios.FindIndex(i => i.Descricao == obj.Criterio.Descricao);
                MatrizAtividades[l, c, d] = obj.Nota;
                MatrizAtividades[c, l, d] = Double.IsInfinity(1 / obj.Nota) ? 0 : 1 / obj.Nota;
            }

            for (int i = 0; i < criterios.Count; i++)
            {
                for (int j = 0; j < atividades.Count; j++)
                {
                    double somaColuna = 0;
                    for (int k = 0; k < atividades.Count; k++)
                    {
                        somaColuna += MatrizAtividades[j, k, i];
                    }

                    for (int k = 0; k < atividades.Count; k++)
                    {
                        MatrizAtividades[j, k, i] /= somaColuna;
                    }
                }
            }
        }

        public void preencherListaAtividades()
        {
            vetEigenAtividades = new double[criterios.Count, atividades.Count];
            for (int i = 0; i < criterios.Count; i++)
            {
                //   List<double> listaAtividades = new List<double>();
                //int j;
                for (int j = 0; j < atividades.Count; j++)
                {
                    double soma = 0;
                    for (int k = 0; k < atividades.Count; k++)
                    {
                        soma += MatrizAtividades[j, k, i];
                    }
                    vetEigenAtividades[i, j] = soma / atividades.Count;
                    // listaAtividades.Add(soma / atividades.Count);
                }
                //vetEigenAtividades[j,k];
                for (int j = 0; j < atividades.Count; j++)
                {
                    double soma = 0;
                    for (int k = 0; k < atividades.Count; k++)
                    {
                        soma += MatrizAtividades[j, k, i];
                    }
                }
            }
        }

        public void gerarRelatorio()
        {
            // int j = 0;
            for (int i = 0; i < atividades.Count; i++)
            {
                double produto = 0;
                for (int j = 0; j < criterios.Count; j++)
                {
                    produto += vetEigenAtividades[j, i] * vetEigenCriterios[j];
                }
                listaRelatorio.Add(produto);
            }
        }
    }
}
