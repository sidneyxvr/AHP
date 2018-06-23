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
    public partial class RemoverPortfolioUI : Form
    {
        private PortfolioUI parent = null;
        public RemoverPortfolioUI(PortfolioUI _parent)
        {
            InitializeComponent();
            this.parent = _parent;
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            string id = this.parent.retornarMarcado();
            PortfolioBLL bll = new PortfolioBLL();
            bll.Remover(id);
        }
    }
}
