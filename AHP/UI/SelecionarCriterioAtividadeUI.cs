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
    public partial class SelecionarCriterioAtividadeUI : Form
    {
        private PortfolioCriterioBLL portfolioCriterio;
        private List<CheckBox> listCheckBoxCriterio;
        List<Tuple<Criterio, bool>> listCriterios;

        private PortfolioAtividadeBLL portfolioAtividade;
        private List<CheckBox> listCheckBoxAtividade;
        List<Tuple<Atividade, bool>> listAtividades;

        private int portfolioId;

        public SelecionarCriterioAtividadeUI(int portfolioId)
        {
            InitializeComponent();
            portfolioCriterio = new PortfolioCriterioBLL();
            listCheckBoxCriterio = new List<CheckBox>();
            portfolioAtividade = new PortfolioAtividadeBLL();
            listCheckBoxAtividade = new List<CheckBox>();
            this.portfolioId = portfolioId;
        }

        private void RelacionarCriterioUI_Load(object sender, EventArgs e)
        {
            preencherCheckCriterio();
            preencherCheckAtividade();
        }

        private void preencherCheckCriterio()
        {
            listCriterios = portfolioCriterio.Listar(portfolioId);
            for (int i = 0; i < listCriterios.Count; i++)
            {
                listCheckBoxCriterio.Add(new CheckBox());
                listCheckBoxCriterio[i].Location = new Point(20, (i * 20) + 20);
                listCheckBoxCriterio[i].Text = listCriterios[i].Item1.Descricao;
                Point p = listCheckBoxCriterio[i].Location;
                listCheckBoxCriterio[i].Checked = listCriterios[i].Item2;
                var b = listCheckBoxCriterio[i].Checked;
                groupBoxCriterio.Controls.Add(listCheckBoxCriterio[i]);
                listCheckBoxCriterio[i].CheckedChanged += new EventHandler(criterioSelecionado);
            }
        }

        private void preencherCheckAtividade()
        {
            listAtividades = portfolioAtividade.Listar(portfolioId);
            for (int i = 0; i < listAtividades.Count; i++)
            {
                listCheckBoxAtividade.Add(new CheckBox());
                listCheckBoxAtividade[i].Location = new Point(20, (i * 20) + 20);
                listCheckBoxAtividade[i].Text = listAtividades[i].Item1.Descricao;
                Point p = listCheckBoxAtividade[i].Location;
                listCheckBoxAtividade[i].Checked = listAtividades[i].Item2;
                var b = listCheckBoxAtividade[i].Checked;
                groupBoxAtividade.Controls.Add(listCheckBoxAtividade[i]);
                listCheckBoxAtividade[i].CheckedChanged += new EventHandler(atividadeSelecionado);
            }
        }

        private void criterioSelecionado(Object sender, EventArgs e)
        {
            CheckBox ck = (CheckBox)sender;
            PortfolioCriterio pc = new PortfolioCriterio()
            {
                Portfolio = new Portfolio()
                {
                    ID = portfolioId
                },
                Criterio = new Criterio()
                {
                    ID = (listCriterios.Where(i => i.Item1.Descricao == ck.Text)).Select(i => i.Item1.ID).First()
                }
            };
            if (ck.Checked == true)
            {
                portfolioCriterio.Adicionar(pc);
            }
            else
            {
                portfolioCriterio.Excluir(pc);
            }
        }

        private void atividadeSelecionado(Object sender, EventArgs e)
        {
            CheckBox ck = (CheckBox)sender;
            PortfolioAtividade pa = new PortfolioAtividade()
            {
                Portfolio = new Portfolio()
                {
                    ID = portfolioId
                },
                Atividade = new Atividade()
                {
                    ID = (listAtividades.Where(i => i.Item1.Descricao == ck.Text)).Select(i => i.Item1.ID).First()
                }
            };
            if (ck.Checked == true)
            {
                portfolioAtividade.Adicionar(pa);
            }
            else
            {
                portfolioAtividade.Excluir(pa);
            }
        }

        private void RelacionarCriterioUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
