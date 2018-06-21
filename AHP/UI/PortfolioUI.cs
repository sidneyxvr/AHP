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
    public partial class PortfolioUI : Form
    {
        public PortfolioUI()
        {
            InitializeComponent();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarPortfolioUI form = new AdicionarPortfolioUI();
            form.ShowDialog();
        }

        private void PortfolioUI_Load(object sender, EventArgs e)
        {
            PortfolioBLL bll = new PortfolioBLL();
            grid.DataSource = bll.Listar();
        }
    }
}
