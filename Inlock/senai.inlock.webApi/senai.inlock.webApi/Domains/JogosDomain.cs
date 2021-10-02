using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public DateTime dataLançamento { get; set; }
        public float valor { get; set; }

    }
}
