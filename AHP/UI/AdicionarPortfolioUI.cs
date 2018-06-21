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
        public AdicionarPortfolioUI()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            PortfolioBLL bll = new PortfolioBLL();
            bll.Adicionar(new Portfolio()
            {
                Descricao = txtDescricao.Text
            });
        }
    }
}
