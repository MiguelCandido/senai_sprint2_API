using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IUsuariosRepository
    {
        /// <summary>
        /// Loga o usuário
        /// </summary>
        /// <param name="UserLog">Credenciais de login</param>
        /// <returns></returns>
        UsuariosDomain Logar(UsuariosDomain UserLog);
    }
}
