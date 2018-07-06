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
using System.Windows.Forms.DataVisualization.Charting;

namespace AHP.UI
{
    public partial class RelatorioUI : Form
    {
        private double[,] matrizCriterios;
        private double[,,] matrizAtividades;
        private RelatorioBLL rBll;
        private List<Label> listLabelAtividades;
        private List<Label> listLabelCriterios;
        private List<Label> listLabelNotaAtividades;
        private List<Label> listLabelNotaCriterios;

        public RelatorioUI(int portfolioId)
        {
            InitializeComponent();
            rBll = new RelatorioBLL(portfolioId);
            matrizCriterios = rBll.MatrizCriterios;
            matrizAtividades = rBll.MatrizAtividades;
            listLabelAtividades = new List<Label>();
            listLabelCriterios = new List<Label>();
            listLabelNotaCriterios = new List<Label>();
        }


        private void alocarChartAtividade()
        {
            int j = 0;
            foreach(var i in rBll.ListaRelatorioAtividade)
            {
                //chart1.Series[0].Points.Add(new DataPoint(i.Item2, i.Item1));

                chart1.Series["Series1"].Label = "#PERCENT{0.00 %}";
                chart1.Series["Series1"].Points.AddY(i.Item2);
                chart1.Series["Series1"].IsValueShownAsLabel = true;
                chart1.Series["Series1"].Points[j].LegendText = i.Item1;
                j++;
            }
        }

        private void alocarChartCriterios()
        {
            int j = 0;
            foreach (var i in rBll.VetEigenCriterios)
            {
                //chart1.Series[0].Points.Add(new DataPoint(i.Item2, i.Item1));

                chart2.Series["Series1"].Label = "#PERCENT{0.00 %}";
                chart2.Series["Series1"].Points.AddY(i.Item2);
                chart2.Series["Series1"].IsValueShownAsLabel = true;
                chart2.Series["Series1"].Points[j].LegendText = i.Item1;
                j++;
            }
        }

        private void RelatorioUI_Load(object sender, EventArgs e)
        {
            alocarChartAtividade();
            alocarChartCriterios();
            if(rBll.ConsistenciaCriterios == false)
            {
                MessageBox.Show("Matriz de Critérios Inconsistente");
            }
            if(rBll.ConsistenciaAtividades.Item1 == false)
            {
                MessageBox.Show("Matriz " + rBll.ConsistenciaAtividades.Item2 + " de Atividades Inconsistente" );
            }
        }
    }
}
