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

        private void PortfolioUI_Load(object sender, EventArgs e)
        {
            PortfolioBLL bll = new PortfolioBLL();
            grid.DataSource = bll.Listar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarPortfolioUI form = new AdicionarPortfolioUI();
            form.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            RemoverPortfolioUI form = new RemoverPortfolioUI(this);
            form.ShowDialog();
            //string id = grid.CurrentRow.Cells["ID"].Value.ToString();
            //PortfolioBLL bll = new PortfolioBLL();
            //bll.Remover(id);
            //DataGridViewRow linhaAtual = grid.CurrentRow;
            //int indice = linhaAtual.Index;
            //var linhaSelec = grid.CurrentRow.Index;
            // configurando valor da primeira coluna, índice 0
            //string id = grid.Rows[indice].Cells[0].Value.ToString();
            //int id = Convert.ToInt32(grid.Rows[indice].Cells[0].Value);
            // MessageBox.Show(id);

        }

        public string retornarMarcado()
        {
            return this.grid.CurrentRow.Cells["ID"].Value.ToString();
        }
    }
}
