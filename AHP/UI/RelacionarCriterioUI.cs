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
    public partial class RelacionarCriterioUI : Form
    {
        private CriterioBLL criterio;
        private AtividadeBLL atividade;
        private List<CheckBox> listCheckBoxCriterio;
        private List<CheckBox> listCheckBoxAtividade;

        public RelacionarCriterioUI(int id)
        {
            InitializeComponent();
            criterio = new CriterioBLL();
            atividade = new AtividadeBLL();
            listCheckBoxCriterio = new List<CheckBox>();
            listCheckBoxAtividade = new List<CheckBox>();
        }

        private void RelacionarCriterioUI_Load(object sender, EventArgs e)
        {
            preencherCheckCriterio();
            preencherCheckAtividade();
            nada();
        }

        private void preencherCheckCriterio()
        {
            List<Criterio> listCriterio = criterio.Listar();
            for (int i = 0; i < listCriterio.Count; i++)
            {
                listCheckBoxCriterio.Add(new CheckBox());
                listCheckBoxCriterio[i].Location = new Point(20, (i * 20) + 20);
                listCheckBoxCriterio[i].Text = listCriterio[i].Descricao;
                Point p = listCheckBoxCriterio[i].Location;
                groupBoxCriterio.Controls.Add(listCheckBoxCriterio[i]);
            }
        }

        private void preencherCheckAtividade()
        {
            List<Atividade> listAtividade = atividade.Listar();
            for (int i = 0; i < listAtividade.Count; i++)
            {
                listCheckBoxAtividade.Add(new CheckBox());
                listCheckBoxAtividade[i].Location = new Point(20, (i * 20) + 20);
                listCheckBoxAtividade[i].Text = listAtividade[i].Descricao;
                Point p = listCheckBoxAtividade[i].Location;
                groupBoxAtividade.Controls.Add(listCheckBoxAtividade[i]);
            }
        }

        private void nada()
        {
            foreach(CheckBox i in listCheckBoxCriterio)
            {
                i.CheckedChanged += new EventHandler(selecionado);
            }
        }

        private void selecionado(Object sender, EventArgs e)
        {
            CheckBox ck = (CheckBox)sender;
            if(ck.Checked == true)
            {
                MessageBox.Show("(y)");
            }
            else
            {
                MessageBox.Show("(_I_)");
            }
        }
    }
}
