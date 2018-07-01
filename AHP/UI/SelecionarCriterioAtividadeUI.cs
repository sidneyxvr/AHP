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
        private PortfolioCriterioBLL portfolioCriterioBLL;
        private PortfolioAtividadeBLL portfolioAtividadeBLL;
        private List<CheckBox> listCheckBoxCriterio;
        List<Tuple<Criterio, bool>> listCriterios;

        private List<CheckBox> listCheckBoxAtividade;
        List<Tuple<Atividade, bool>> listAtividades;

        private int portfolioId;

        public SelecionarCriterioAtividadeUI(int portfolioId)
        {
            InitializeComponent();
            portfolioCriterioBLL = new PortfolioCriterioBLL();
            portfolioAtividadeBLL = new PortfolioAtividadeBLL();
            listCheckBoxCriterio = new List<CheckBox>();
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
            listCriterios = portfolioCriterioBLL.Listar(portfolioId);
            for (int i = 0; i < listCriterios.Count; i++)
            {
                listCheckBoxCriterio.Add(new CheckBox());
                listCheckBoxCriterio[i].Location = new Point(20, (i * 20) + 20);
                listCheckBoxCriterio[i].Text = listCriterios[i].Item1.Descricao;
                listCheckBoxCriterio[i].Checked = listCriterios[i].Item2;
                groupBoxCriterio.Controls.Add(listCheckBoxCriterio[i]);
                listCheckBoxCriterio[i].CheckedChanged += new EventHandler(criterioSelecionado);
            }
        }

        private void preencherCheckAtividade()
        {
            listAtividades = portfolioAtividadeBLL.Listar(portfolioId);
            for (int i = 0; i < listAtividades.Count; i++)
            {
                listCheckBoxAtividade.Add(new CheckBox());
                listCheckBoxAtividade[i].Location = new Point(20, (i * 20) + 20);
                listCheckBoxAtividade[i].Text = listAtividades[i].Item1.Descricao;
                listCheckBoxAtividade[i].Checked = listAtividades[i].Item2;
                groupBoxAtividade.Controls.Add(listCheckBoxAtividade[i]);
                listCheckBoxAtividade[i].CheckedChanged += new EventHandler(atividadeSelecionado);
            }
        }

        private void criterioSelecionado(Object sender, EventArgs e)
        {
            CheckBox ck = (CheckBox)sender;
            List<Criterio> lista;
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
                portfolioCriterioBLL.Adicionar(pc);
                lista = portfolioCriterioBLL.ListarPorPortfolio(portfolioId);
                foreach (Criterio c in lista)
                {
                    portfolioCriterioBLL.AdicionarRelacaoCriterioPortfolio(new RelacaoCriterio()
                    {
                        Criterio1 = new Criterio()
                        {
                            ID = pc.Criterio.ID
                        },
                        Criterio2 = new Criterio()
                        {
                            ID = c.ID
                        },
                        Nota = pc.Criterio.ID == c.ID ? 1.0: 0.0,
                        Portfolio = new Portfolio()
                        {
                            ID = pc.Portfolio.ID
                        }
                    });
                }
                check(pc.Criterio.ID);
            }
            else
            {
                lista = portfolioCriterioBLL.ListarPorPortfolio(portfolioId);
                foreach (Criterio c in lista)
                {
                    portfolioCriterioBLL.ExcluirRelacaoCriterioPortfolio(new RelacaoCriterio()
                    {
                        Criterio1 = new Criterio()
                        {
                            ID = pc.Criterio.ID
                        },
                        Portfolio = new Portfolio()
                        {
                            ID = pc.Portfolio.ID
                        }
                    });
                    portfolioCriterioBLL.Excluir(pc);
                }
            }
        }

        private void atividadeSelecionado(Object sender, EventArgs e)
        {
            CheckBox ck = (CheckBox)sender;
            List<Criterio> listC = portfolioCriterioBLL.ListarPorPortfolio(portfolioId);
            List<Atividade> listA;
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
                portfolioAtividadeBLL.Adicionar(pa);
                listA = portfolioAtividadeBLL.ListarPorPortfolio(portfolioId);
                foreach (Criterio c in listC)
                {
                    foreach(Atividade a in listA)
                    {
                        portfolioAtividadeBLL.AdicionarRelacaoAtividadePortfolio(new RelacaoAtividade()
                        {
                            Atividade1 = new Atividade()
                            {
                                ID = pa.Atividade.ID
                            },
                            Atividade2 = new Atividade()
                            {
                                ID = a.ID
                            },
                            Criterio = new Criterio()
                            {
                                ID = c.ID
                            },
                            Nota = pa.Atividade.ID == a.ID ? 1.0: 0.0,
                            Portfolio = new Portfolio()
                            {
                                ID = pa.Portfolio.ID
                            }
                        });
                    }
                }
            }
            else
            {
                listA = portfolioAtividadeBLL.ListarPorPortfolio(portfolioId);
                foreach (Criterio c in listC)
                {
                    foreach (Atividade a in listA)
                    {
                        portfolioAtividadeBLL.ExcluirRelacaoAtividadePortfolio(new RelacaoAtividade()
                        {
                            Atividade1 = new Atividade()
                            {
                                ID = pa.Atividade.ID
                            },
                            Atividade2 = new Atividade()
                            {
                                ID = a.ID
                            },
                            Criterio = new Criterio()
                            {
                                ID = c.ID
                            },
                            Nota = pa.Atividade.ID == a.ID ? 1.0 : 0.0,
                            Portfolio = new Portfolio()
                            {
                                ID = pa.Portfolio.ID
                            }
                        });
                    }
                }
                portfolioAtividadeBLL.Excluir(pa);
            }
        }

        private void check(int criterioId)
        {
            List<Atividade> listA = portfolioAtividadeBLL.ListarPorPortfolio(portfolioId);
            if (listA.Count > 0)
            {
                for (int i = 0; i < listA.Count; i++)
                {
                    for (int j = i; j < listA.Count; j++)
                    {
                        portfolioAtividadeBLL.AdicionarRelacaoAtividadePortfolio(new RelacaoAtividade()
                        {
                            Atividade1 = new Atividade()
                            {
                                ID = listA[j].ID
                            },
                            Atividade2 = new Atividade()
                            { 
                                ID = listA[i].ID
                            },
                            Criterio = new Criterio()
                            {
                                ID = criterioId
                            },
                            Nota = listA[i].ID == listA[j].ID ? 1.0 : 0.0,
                            Portfolio = new Portfolio()
                            {
                                ID = portfolioId
                            }
                        });
                    }
                }
            }
        }

        private void RelacionarCriterioUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
