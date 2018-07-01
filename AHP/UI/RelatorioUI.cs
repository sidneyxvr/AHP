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

        public RelatorioUI(int portfolioId)
        {
            InitializeComponent();
            rBll = new RelatorioBLL(portfolioId);
            matrizCriterios = rBll.MatrizCriterios;
            matrizAtividades = rBll.MatrizAtividades;

        }
    }
}
