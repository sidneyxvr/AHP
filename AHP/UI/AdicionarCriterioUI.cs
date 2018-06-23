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
    }
}
