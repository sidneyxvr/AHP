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
    public partial class RelacionarCriterioAtividadeUI : Form
    {
        private int portfolioId;
        private RelacaoCriterioBLL rcBll;
        private RelacaoAtividadeBLL raBll;

        List<Label> listLabelHorizontalCriterio;
        List<Label> listLabelVerticalCriterio;
        List<List<TextBox>> listTextBoxCriterio;
        List<Criterio> criterios;

        List<Label> listLabelHorizontalAtividade;
        List<Label> listLabelVerticalAtividade;
        List<List<TextBox>> listTextBoxAtividade;
        List<Atividade> atividades;


        public RelacionarCriterioAtividadeUI(int portfolioId)
        {
            InitializeComponent();
            this.portfolioId = portfolioId;
            rcBll = new RelacaoCriterioBLL();
            listLabelHorizontalCriterio = new List<Label>();
            listLabelVerticalCriterio = new List<Label>();
            listTextBoxCriterio = new List<List<TextBox>>();

            raBll = new RelacaoAtividadeBLL();
            listLabelHorizontalAtividade = new List<Label>();
            listLabelVerticalAtividade = new List<Label>();
            listTextBoxAtividade = new List<List<TextBox>>();
            atividades = new List<Atividade>();
            
            criterios = rcBll.ListarCriterios(portfolioId).OrderBy(i => i.Descricao).ToList();
            atividades = raBll.ListarAtividades(portfolioId).OrderBy(i => i.Descricao).ToList();
        }

        private void RelacionarCriterioAtividade_Load(object sender, EventArgs e)
        {
            //====================================TAB_CRITERIO=====================================
            alocarLabelsHorizontal(ref criterios, ref listLabelHorizontalCriterio, ref panelCriterioHorizontal);
            alocarLabelsVertical(ref criterios, ref listLabelVerticalCriterio, ref panelCriterioVertical);
            alocarTextBox(ref criterios, ref listTextBoxCriterio, ref panelCriterioPrincipal);
            carregarTextBoxCriterio();
            //====================================TAB_ATIVIDADE====================================
            alocarLabelsHorizontal(ref atividades, ref listLabelHorizontalAtividade, ref panelAtividadeHorizontal);
            alocarLabelsVertical(ref atividades, ref listLabelVerticalAtividade, ref panelAtividadeVertical);
            alocarTextBox(ref atividades, ref listTextBoxAtividade, ref panelAtividadePrincipal);
            preencherComboBoxCriterio();
        }
        
        public void alocarLabelsHorizontal<T>(ref List<T> list, ref List<Label> listLabelHorizontal, ref Panel panel)
        {
            for(int i = 0; i < list.Count; i++)
            {
                listLabelHorizontal.Add(new Label());
                listLabelHorizontal.Last().Width = 50;
                if (list[i] is Criterio)
                {
                    listLabelHorizontal.Last().Text = criterios.ElementAt(i).Descricao;
                }
                else
                {
                    listLabelHorizontal.Last().Text = atividades.ElementAt(i).Descricao;
                }
                listLabelHorizontal.Last().Location = new Point(i * 60, 10);
                panel.Controls.Add(listLabelHorizontal.Last());
            }
        }

        public void alocarLabelsVertical<T>(ref List<T> list, ref List<Label> listLabelVertical, ref Panel panel)
        {
            for (int i = 0; i < list.Count; i++)
            {
                listLabelVertical.Add(new Label());
                listLabelVertical.Last().Width = 50;
                if (list[i] is Criterio)
                {
                    listLabelVertical.Last().Text = criterios.ElementAt(i).Descricao;
                }
                else
                {
                    listLabelVertical.Last().Text = atividades.ElementAt(i).Descricao;
                }
                listLabelVertical.Last().Location = new Point(10, i * 40);
                panel.Controls.Add(listLabelVertical.Last());
            }
        }

        public void alocarTextBox<T>(ref List<T> list, ref List<List<TextBox>> listTextBox, ref Panel panel)
        {
            for (int i = 0; i < list.Count; i++)
            {
                listTextBox.Add(new List<TextBox>());
                for (int j = 0; j < list.Count; j++)
                {
                    listTextBox[i].Add(new TextBox());
                    listTextBox[i][j].Size = new Size(50, 30);
                    listTextBox[i][j].Location = new Point((i * 60), (j * 40));
                    if (list[i] is Criterio)
                    { 
                        listTextBox[i][j].LostFocus += new EventHandler(eventCriterio);
                    }
                    else
                    {
                        listTextBox[i][j].LostFocus += new EventHandler(eventAtividade);
                    }
                    
                    panel.Controls.Add(listTextBox[i][j]);
                }
            }
        }

        private Tuple<int, int> getPosition<T>(ref List<T> list, ref TextBox t, ref List<List<TextBox>> listTextBox)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (t.Equals(listTextBox[i][j]))
                    {
                        return new Tuple<int, int>(i ,j);
                    }
                }
            }
            return new Tuple<int, int>(-1, -1);
        }

        private string arredondar(string nota)
        {
            if (Double.IsInfinity(Convert.ToDouble(nota)))
            {
                return "0";
            }
            double EPS = 0.00001;
            bool isDouble = nota.Split('.').Count() > 0 ? true : false;
            if (isDouble)
            {
                if (Convert.ToDouble(nota) - Convert.ToUInt32(Convert.ToDouble(nota)) < EPS)
                {
                    return Convert.ToUInt32(Convert.ToDouble(nota)).ToString();
                }
            }
            return nota;
        }

        private void RelacionarCriterioAtividadeUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Dispose();
        }

        private void cbxAtividade_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarTextBoxAtividade();
        }

        /*===================================================================================================
         ====================================== TAB_CRITERIO ================================================
         ===================================================================================================*/
        private void carregarTextBoxCriterio()
        {
            List<RelacaoCriterio> list = rcBll.ListarPorPortfolio(portfolioId)
                                            .OrderBy(i => i.Criterio1.Descricao)
                                            .OrderBy(i => i.Criterio2.Descricao)
                                            .ToList();
            foreach (var obj in list)
            {
                var i = listLabelVerticalCriterio.FindIndex(k => k.Text == obj.Criterio1.Descricao);
                var j = listLabelHorizontalCriterio.FindIndex(k => k.Text == obj.Criterio2.Descricao);
                if (i == j)
                {
                    listTextBoxCriterio[i][j].Enabled = false;
                }
                listTextBoxCriterio[j][i].Text = arredondar((1 / Convert.ToDouble(obj.Nota.ToString())).ToString());
                listTextBoxCriterio[i][j].Text = arredondar(obj.Nota.ToString());
            }
        }

        public void eventCriterio(Object sender, EventArgs e)
        {
            TextBox t = ((TextBox)sender);
            if (Convert.ToDouble(t.Text) < 0 || Convert.ToDouble(t.Text) > 9 || t.Text.Trim() == "")
            {
                MessageBox.Show("Valor Inválido");
                t.Focus();
                return;
            }
            Tuple<int, int> point = getPosition(ref criterios, ref t, ref listTextBoxCriterio);

            RelacaoCriterio r = new RelacaoCriterio()
            {
                Criterio1 = new Criterio()
                {
                    ID = criterios.Where(i => i.Descricao == listLabelHorizontalCriterio[point.Item1].Text).First().ID
                },
                Criterio2 = new Criterio()
                {
                    ID = criterios.Where(i => i.Descricao == listLabelVerticalCriterio[point.Item2].Text).First().ID
                },
                Nota = Convert.ToDouble(listTextBoxCriterio[point.Item1][point.Item2].Text),
                Portfolio = new Portfolio()
                {
                    ID = portfolioId
                }
            };
            listTextBoxCriterio[point.Item2][point.Item1].Text = arredondar((1 / Convert.ToDouble(listTextBoxCriterio[point.Item1][point.Item2].Text)).ToString());
            if(!rcBll.Verificar(r))
            {
                int c = r.Criterio1.ID;
                r.Criterio1.ID = r.Criterio2.ID;
                r.Criterio2.ID = c;
                r.Nota = 1 / r.Nota;
                if (Double.IsInfinity(r.Nota))
                {
                    r.Nota = 0.0;
                }
            }
            rcBll.Alterar(r);
        }

        /*===================================================================================================
         ====================================== TAB_ATIVIDADE ===============================================
         ===================================================================================================*/
        private void preencherComboBoxCriterio()
        {
            cbxCriterio.DataSource = criterios.Select(i => i.Descricao).ToList();
        }

        public void eventAtividade(Object sender, EventArgs e)
        {
            TextBox t = ((TextBox)sender);
            if (Convert.ToDouble(t.Text) < 0 || Convert.ToDouble(t.Text) > 9 || t.Text.Trim() == "")
            {
                MessageBox.Show("Valor Inválido");
                t.Focus();
                return;
            }
            Tuple<int, int> point = getPosition(ref atividades, ref t, ref listTextBoxAtividade);

            RelacaoAtividade r = new RelacaoAtividade()
            {
                Atividade1 = new Atividade()
                {
                    ID = atividades.Where(i => i.Descricao == listLabelHorizontalAtividade[point.Item1].Text).First().ID
                },
                Atividade2 = new Atividade()
                {
                    ID = atividades.Where(i => i.Descricao == listLabelVerticalAtividade[point.Item2].Text).First().ID
                },
                Criterio = new Criterio()
                {
                    ID = criterios.Where(i => i.Descricao == cbxCriterio.Text).Select(i => i.ID).First()
                },
                Nota = Convert.ToDouble(t.Text),
                Portfolio = new Portfolio()
                {
                    ID = portfolioId
                }
            };
            listTextBoxAtividade[point.Item2][point.Item1].Text = arredondar((1 / Convert.ToDouble(listTextBoxAtividade[point.Item1][point.Item2].Text)).ToString());
            if (!raBll.Verificar(r))
            {
                int c = r.Atividade1.ID;
                r.Atividade1.ID = r.Atividade2.ID;
                r.Atividade2.ID = c;
                r.Nota = 1 / r.Nota;
                if(Double.IsInfinity(r.Nota))
                {
                    r.Nota = 0.0;
                }
            }
            raBll.Alterar(r);
        }

        private void carregarTextBoxAtividade()
        {
            if (cbxCriterio.Text.Trim() == "")
            {
                return;
            }
            List<RelacaoAtividade> list = raBll.ListarPorPortfolio(portfolioId)
                                               .Where(i => i.Criterio.Descricao == cbxCriterio.Text.Trim())
                                               .OrderBy(i => i.Atividade1.Descricao)
                                               .OrderBy(i => i.Atividade2.Descricao)
                                               .ToList();
            foreach (var obj in list)
            {
                var i = listLabelVerticalAtividade.FindIndex(k => k.Text == obj.Atividade1.Descricao);
                var j = listLabelHorizontalAtividade.FindIndex(k => k.Text == obj.Atividade2.Descricao);
                if (i == j)
                {
                    listTextBoxAtividade[i][j].Enabled = false;
                }
                listTextBoxAtividade[j][i].Text = arredondar((1 / Convert.ToDouble(obj.Nota.ToString())).ToString());
                listTextBoxAtividade[i][j].Text = arredondar(obj.Nota.ToString());
            }
        }

        private void RelacionarCriterioAtividadeUI_SizeChanged(object sender, EventArgs e)
        {
            this.tabRelacaoCriterioAtividade.Location = new Point((this.Width / 2) - (tabRelacaoCriterioAtividade.Width / 2),
                                                                  (this.Height / 2) - (tabRelacaoCriterioAtividade.Height / 2));
        }
    }
}
