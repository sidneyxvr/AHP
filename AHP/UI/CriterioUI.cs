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
    public partial class CriterioUI: Form
    {
        private CriterioBLL bll;

        public CriterioUI()
        {
            InitializeComponent();
            bll = new CriterioBLL();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarCriterioUI formAdicionarCriterio = new AdicionarCriterioUI(this);
            formAdicionarCriterio.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.SelectedRows.Count; i++)
            {
                DialogResult dialogResult = MessageBox.Show("Certeza?", "Excluir portfólio", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bll.Excluir(Convert.ToInt32(grid.SelectedRows[i].Cells[0].Value));
                }
                carregarLista();
            }
        }

        private void CriterioUI_Load(object sender, EventArgs e)
        {
            centralizar();
            carregarLista();
        }

        public void carregarLista()
        {
            grid.DataSource = bll.Listar();
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[0].Width = 200;
            grid.Columns[0].ReadOnly = true;
            grid.Columns[1].HeaderText = "Critério";
            grid.Columns[1].Width = 400;
            grid.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 10);
            grid.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 10);
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bll.Alterar(new Criterio()
            {
                ID = Convert.ToInt32(grid[0, e.RowIndex].Value),
                Descricao = grid[e.ColumnIndex, e.RowIndex].Value.ToString()
            });
        }

        private void CriterioUI_SizeChanged(object sender, EventArgs e)
        {
            centralizar();
        }

        private void centralizar()
        {
            this.panelMain.Location = new Point((this.Width / 2) - (panelMain.Width / 2),
                                                (this.Height / 2) - (panelMain.Height / 2));
        }
    }
}
