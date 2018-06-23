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
    public partial class AdicionarAtividadeUI : Form
    {
        AtividadeUI form;
        public AdicionarAtividadeUI(AtividadeUI form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AtividadeBLL bll = new AtividadeBLL();
            bll.Adicionar(new Atividade()
            {
                Descricao = txtDescricao.Text
            });
            form.carregarLista();
        }
    }
}
