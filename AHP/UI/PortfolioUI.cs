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
    public partial class PortfolioUI : Form
    {
        PortfolioBLL bll;
        public PortfolioUI()
        {
            InitializeComponent();
            bll = new PortfolioBLL();
        }
        private void PortfolioUI_Load(object sender, EventArgs e)
        {
            centralizar();
            carregarLista();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarPortfolioUI formAdicionarPortfolio = new AdicionarPortfolioUI(this);
            formAdicionarPortfolio.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.SelectedRows.Count; i++)
            {
                DialogResult dialogResult = MessageBox.Show("Sure?", "Excluir portfólio", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bll.Excluir(Convert.ToInt32(grid.SelectedRows[i].Cells[0].Value));
                }
                carregarLista();
            }
        }

        public void carregarLista()
        {
            grid.DataSource = bll.Listar();
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[0].Width = 150;
            grid.Columns[0].ReadOnly = true;
            grid.Columns[1].HeaderText = "Descrição";
            grid.Columns[1].Width = 300;
            grid.Columns[2].HeaderText = "Data de Criação";
            grid.Columns[2].Width = 150;
            grid.Columns[2].ReadOnly = true;
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtividadeUI formAtividade = new AtividadeUI();
            formAtividade.Show();
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bll.Alterar(new Portfolio()
            {
                ID = Convert.ToInt32(grid[0, e.RowIndex].Value),
                Descricao = grid[e.ColumnIndex, e.RowIndex].Value.ToString()
            });
        }

        private void critérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriterioUI formCriterio = new CriterioUI();
            formCriterio.Show();
        }

        private void btnRelacionar_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                return;
            }
            SelecionarCriterioAtividadeUI formRelacionarCriterio = new SelecionarCriterioAtividadeUI(Convert.ToInt32(grid.SelectedRows[0].Cells[0].Value));
            formRelacionarCriterio.Show();
        }

        private void btnGerenciar_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                return;
            }
            RelacionarCriterioAtividadeUI formGerenciarCriterio = new RelacionarCriterioAtividadeUI(Convert.ToInt32(grid.SelectedRows[0].Cells[0].Value));
            formGerenciarCriterio.Show();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                return;
            }
            RelatorioUI formRelatorio = new RelatorioUI(Convert.ToInt32(grid.SelectedRows[0].Cells[0].Value));
            formRelatorio.Show();
        }

        private void PortfolioUI_SizeChanged(object sender, EventArgs e)
        {
            centralizar();
        }

        public void centralizar()
        {
            this.panelMain.Location = new Point((this.Width / 2) - (panelMain.Width / 2),
                                                (this.Height / 2) - (panelMain.Height / 2));
        }
    }
}