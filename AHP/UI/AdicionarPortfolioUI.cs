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
    public partial class AdicionarPortfolioUI : Form
    {
        PortfolioUI form;
        public AdicionarPortfolioUI(PortfolioUI form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            PortfolioBLL bll = new PortfolioBLL();
            bll.Adicionar(new Portfolio()
            {
                Descricao = txtDescricao.Text
            });
            form.carregarLista();
        }

        private void AdicionarPortfolioUI_SizeChanged(object sender, EventArgs e)
        {
            this.panelMain.Location = new Point((this.Width / 2) - (panelMain.Width / 2),
                                                (this.Height / 2) - (panelMain.Height / 2));
        }
    }
}
