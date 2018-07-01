using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Entidades
{
    class RelacaoAtividade
    {
        public Atividade Atividade1 { get; set; }
        public Atividade Atividade2 { get; set; }
        public Criterio Criterio { get; set; }
        public double Nota { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
