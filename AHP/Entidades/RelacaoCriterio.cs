using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Entidades
{
    class RelacaoCriterio
    {
        public Criterio Criterio1 { get; set; }
        public Criterio Criterio2 { get; set; }
        public Portfolio Portfolio { get; set; }
        public double Nota { get; set; }
    }
}
