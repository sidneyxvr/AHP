﻿using AHP.Dados;
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
        private double[] indiceConsistenciaAleatoria = {0, 0, 0.58, 0.9, 1.12, 1.24, 1.32, 1.41, 1.45, 1.49};
        private List<double> listaSomaColunasCriterios;
        private List<List<double>> listaSomaColunasAtividades;
        private List<double> vetEigenCriterios;
        private double[,] vetEigenAtividades;
        public List<double> ListaRelatorio { get; set; }
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
            listaSomaColunasCriterios = new List<double>();
            listaSomaColunasAtividades = new List<List<double>>();
            //vetEigenAtividades = new List<List<double>>();
            ListaRelatorio = new List<double>();
            preencherMatrizCriterios();
            preencherVetEngelsCriterios();
            preencherMatrizAtividades();
            preencherVetEngelsAtividades();
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
                for (int j = 0; j < criterios.Count; j++)
                {
                    somaColuna += MatrizCriterios[j, i];
                    //somaColuna += 0;
                }
                listaSomaColunasCriterios.Add(somaColuna);
                for (int j = 0; j < criterios.Count; j++)
                {
                    MatrizCriterios[j, i] /= somaColuna;
                   // double k = MatrizCriterios[j, i];
                }
            }
        }

        public void preencherVetEngelsCriterios()
        {
            for (int i = 0; i < criterios.Count; i++)
            {
                double soma = 0, aux = 0;
                for (int j = 0; j < criterios.Count; j++)
                {
                    soma += MatrizCriterios[i, j];
                    aux = MatrizCriterios[i, j];
                }
                vetEigenCriterios.Add(soma / criterios.Count);
                //aux = soma / criterios.Count;
            }
            bool consistecia = calcularConsistenciaCriterios();
        }

        public bool calcularConsistenciaCriterios()
        {
            double lambda = 0, indiceConsistencia = 0, taxaConsistencia = 0, aux1 = 0, aux2 = 0;
            for(int i = 0; i < listaSomaColunasCriterios.Count; i++)
            {
                lambda += vetEigenCriterios[i] * listaSomaColunasCriterios[i];
                //aux1 = vetEigenCriterios[i];
                //aux2 = listaSomaColunasCriterios[i];
            }
            indiceConsistencia = (lambda - listaSomaColunasCriterios.Count) / (listaSomaColunasCriterios.Count - 1);
            //aux1 = indiceConsistencia;
            taxaConsistencia = indiceConsistencia / indiceConsistenciaAleatoria[listaSomaColunasCriterios.Count - 1];
            return taxaConsistencia < 0.1 ? true : false;
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
                List<double> listaSomaColunas = new List<double>();
                for (int j = 0; j < atividades.Count; j++)
                {
                    double somaColuna = 0;
                    for (int k = 0; k < atividades.Count; k++)
                    {
                        somaColuna += MatrizAtividades[j, k, i];
                    }
                    listaSomaColunas.Add(somaColuna);
                    for (int k = 0; k < atividades.Count; k++)
                    {
                        MatrizAtividades[j, k, i] /= somaColuna;
                    }
                }
                listaSomaColunasAtividades.Add(listaSomaColunas);
            }
        }

        public void preencherVetEngelsAtividades()
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
           // bool consistecia = calcularConsistenciaAtividades();
        }
        /*
        public bool calcularConsistenciaAtividades()
        {
            double lambda = 0, indiceConsistencia = 0, taxaConsistencia = 0, aux1 = 0, aux2 = 0;
            for(int i = 0; i < listaSomaColunasCriterios.Count; i++)
            {
                lambda += vetEigenCriterios[i] * listaSomaColunasCriterios[i];
                //aux1 = vetEigenCriterios[i];
                //aux2 = listaSomaColunasCriterios[i];
            }
            indiceConsistencia = (lambda - listaSomaColunasCriterios.Count) / (listaSomaColunasCriterios.Count - 1);
            //aux1 = indiceConsistencia;
            taxaConsistencia = indiceConsistencia / indiceConsistenciaAleatoria[listaSomaColunasCriterios.Count - 1];
            return taxaConsistencia < 0.1 ? true : false;
        }*/

        public void gerarRelatorio()
        {
            for (int i = 0; i < atividades.Count; i++)
            {
                double produto = 0;
                for (int j = 0; j < criterios.Count; j++)
                {
                    produto += vetEigenAtividades[j, i] * vetEigenCriterios[j];
                }
                ListaRelatorio.Add(produto);
            }
        }
    }
}
