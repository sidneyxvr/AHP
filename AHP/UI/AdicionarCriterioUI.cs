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
    public partial class AdicionarCriterioUI : Form
    {
        CriterioUI form;

        public AdicionarCriterioUI(CriterioUI form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CriterioBLL bll = new CriterioBLL();
            bll.Adicionar(new Criterio()
            {
                Descricao = txtDescricao.Text
            });
            form.carregarLista();
        }

        private void AdicionarCriterioUI_SizeChanged(object sender, EventArgs e)
        {
            centralizar();
        }

        private void centralizar()
        {
            this.panelMain.Location = new Point((this.Width / 2) - (panelMain.Width / 2),
                                                (this.Height / 2) - (panelMain.Height / 2));
        }

        private void AdicionarCriterioUI_Load(object sender, EventArgs e)
        {
            centralizar();
        }
    }
}
