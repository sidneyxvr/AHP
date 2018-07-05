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
        private double[,] matrizCriterios;
        private double[,,] matrizAtividades;
        private RelatorioBLL rBll;
        private List<Label> listLabelAtividades;
        private List<Label> listLabelNota;

        public RelatorioUI(int portfolioId)
        {
            InitializeComponent();
            rBll = new RelatorioBLL(portfolioId);
            matrizCriterios = rBll.MatrizCriterios;
            matrizAtividades = rBll.MatrizAtividades;
            listLabelAtividades = new List<Label>();
            listLabelNota = new List<Label>();
        }


        private void alocarLabelAtividade()
        {
            for(int i = 0; i < rBll.ListaRelatorio.Count; i++)
            {
                Label lbl1 = new Label();
                panelAtividade.Controls.Add(lbl1);
                lbl1.Location = new Point(10, i * 30);
                lbl1.Text = rBll.ListaRelatorio[i].Item1;
                Label lbl2 = new Label();
                panelNota.Controls.Add(lbl2);
                lbl2.Location = new Point(10, i * 30);
                lbl2.Text = (rBll.ListaRelatorio[i].Item2 * 100).ToString().Substring(0,5) + " %";
            }
        }

        private void RelatorioUI_Load(object sender, EventArgs e)
        {
            alocarLabelAtividade();
        }
    }
}
