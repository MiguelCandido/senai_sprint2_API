using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class UsuariosDomain
    {
        public int IdUsuario { get; set; }
        public int IdTipo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
