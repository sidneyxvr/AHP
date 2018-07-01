using AHP.Entidades;
using AHP.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHP.UI
{
    public partial class RelatorioUI : Form
    {
        private List<RelacaoCriterio> listaCriterios;
        private RelacaoCriterioBLL relacaoCriterioBLL;

        public RelatorioUI(int portfolioId)
        {
            InitializeComponent();
            relacaoCriterioBLL = new RelacaoCriterioBLL();
            listaCriterios = relacaoCriterioBLL.ListarPorPortfolio(portfolioId);
            
        }

        private void preencherMatriz()
        {
            Dictionary<string, Dictionary<string, double>> notas = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < listaCriterios.Count; i++)
            {
                Dictionary<string, double> colunas = new Dictionary<string, double>();
                colunas.Add(listaCriterios[i].Criterio2.Descricao, listaCriterios[i].Nota);
                notas.Add(listaCriterios[i].Criterio1.Descricao, colunas);
            }       
            

            for(int i = 0; i < notas.Count; i++)
            {
                int j;
                double somatorio = 0.0;
                for (j = 0; j < notas.Count; j++)
                {
                    somatorio += notas.ElementAt(j).Key.ElementAt(i);
                }
                somatorio /= j + 1;

                for (j = 0; j < notas.Count; j++)
                {
                     notas. /= somatorio;
                }
            }
        }

    }
}
