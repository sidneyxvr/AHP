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
        List<Label> listLabelHorizontal;
        List<Label> listLabelVertical;
        List<List<TextBox>> listTextBox;

        public RelacionarCriterioAtividadeUI(int portfolioId)
        {
            InitializeComponent();
            this.portfolioId = portfolioId;
            rcBll = new RelacaoCriterioBLL(portfolioId);
            listLabelHorizontal = new List<Label>();
            listLabelVertical = new List<Label>();
            listTextBox = new List<List<TextBox>>();
        }

        private void RelacionarCriterioAtividade_Load(object sender, EventArgs e)
        {
            alocarLabelsHorizontal();
            alocarLabelsVertical();
            alocarTextBox();
            carregarTextBox();
        }
        
        public void alocarLabelsHorizontal()
        {
            List<Criterio> criterios = rcBll.ListarCriterios(portfolioId).OrderBy(i => i.Descricao).ToList();
            for(int i = 0; i < criterios.Count; i++)
            {
                listLabelHorizontal.Add(new Label());
                listLabelHorizontal.Last().Width = 50;
                listLabelHorizontal.Last().Text = criterios.ElementAt(i).Descricao;
                listLabelHorizontal.Last().Location = new Point(i * 60, 10);
                panelCriterioHorizontal.Controls.Add(listLabelHorizontal.Last());
            }
        }

        public void alocarLabelsVertical()
        {
            List<Criterio> criterios = rcBll.ListarCriterios(portfolioId).OrderBy(i => i.Descricao).ToList();
            for (int i = 0; i < criterios.Count; i++)
            {
                listLabelVertical.Add(new Label());
                listLabelVertical.Last().Width = 50;
                listLabelVertical.Last().Text = criterios.ElementAt(i).Descricao;
                listLabelVertical.Last().Location = new Point(10, i * 40);
                panelCriterioVertical.Controls.Add(listLabelVertical.Last());
            }
        }

        public void alocarTextBox()
        {
            List<Criterio> criterios = rcBll.ListarCriterios(portfolioId).OrderBy(i => i.Descricao).ToList();
            for (int i = 0; i < criterios.Count; i++)
            {
                listTextBox.Add(new List<TextBox>());
                for (int j = 0; j < criterios.Count; j++)
                {
                    listTextBox[i].Add(new TextBox());
                    listTextBox[i][j].Size = new Size(50, 30);
                    listTextBox[i][j].Location = new Point((i * 60), (j * 40));
                    listTextBox[i][j].Leave += new EventHandler(addEvent);
                    panelPrincipal.Controls.Add(listTextBox[i][j]);
                }
            }
        }

        public void addEvent(Object sender, EventArgs e)
        {
            List<Criterio> criterios = rcBll.ListarCriterios(portfolioId);
            TextBox t = ((TextBox)sender);
            Tuple<int, int> point = getPosition(t);
            listTextBox[point.Item2][point.Item1].Text = (1 / Convert.ToDouble(listTextBox[point.Item1][point.Item2].Text)).ToString();
            if (!(point.Item2 > point.Item1))
            {
                swap(point.Item1, point.Item2);
            }
            rcBll.Alterar(new RelacaoCriterio()
            {
                Criterio1 = new Criterio()
                {
                    ID = criterios.Where(i => i.Descricao == listLabelHorizontal[point.Item1].Text).First().ID
                },
                Criterio2 = new Criterio()
                {
                    ID = criterios.Where(i => i.Descricao == listLabelVertical[point.Item2].Text).First().ID                    
                },
                Nota = Convert.ToDouble(listTextBox[point.Item1][point.Item2].Text),
                Portfolio = new Portfolio()
                {
                    ID = portfolioId
                }
            });
        }

        private Tuple<int, int> getPosition(TextBox t)
        {
            List<Criterio> criterios = rcBll.ListarCriterios(portfolioId);
            for (int i = 0; i < criterios.Count; i++)
            {
                for (int j = 0; j < criterios.Count; j++)
                {
                    if (t.Equals(listTextBox[i][j]))
                    {
                        return new Tuple<int, int>(i ,j);
                    }
                }
            }
            return new Tuple<int, int>(-1, -1);
        }

        private void carregarTextBox()
        {
            List<RelacaoCriterio> list = rcBll.ListarPorPortfolio(portfolioId)
                                            .OrderBy(i => i.Criterio1.Descricao)
                                            .OrderBy(i => i.Criterio2.Descricao)
                                            .ToList();
            foreach(var obj in list)
            {
                var i = listLabelVertical.FindIndex(k => k.Text == obj.Criterio1.Descricao);
                var j = listLabelHorizontal.FindIndex(k => k.Text == obj.Criterio2.Descricao);
                if(i == j)
                {
                    listTextBox[i][j].Enabled = false;
                }
                listTextBox[j][i].Text = (1 / Convert.ToDouble(obj.Nota.ToString())).ToString();
                listTextBox[i][j].Text = obj.Nota.ToString();
            }
        }

        private void swap<T>(T a, T b)
        {
            T c = a;
            a = b;
            b = c;
        }
    }
}
