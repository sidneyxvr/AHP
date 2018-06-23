using AHP.Dados;
using AHP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AHP.Negocios
{
    class PortfolioBLL
    {
        public void Adicionar(Portfolio portfolio)
        {
            Regex rg = new Regex(@"\b[A-Z]\w*\b");
            if(!rg.IsMatch(portfolio.Descricao))
            {
                return;
            }
            PortfolioDAO dao = new PortfolioDAO();
            dao.Adicionar(portfolio);

        }

        public void Remover(string id)
        {

            PortfolioDAO dao = new PortfolioDAO();
            dao.Remover(id);
        }

        public List<Portfolio> Listar()
        {
            PortfolioDAO dao = new PortfolioDAO();
            return dao.Listar();
        }
    }
}
