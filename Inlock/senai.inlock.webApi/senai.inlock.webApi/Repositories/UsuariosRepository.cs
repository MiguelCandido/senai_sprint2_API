using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private string stringConexao = "Data Source=LAPTOP-7R4I65FT\\SQLEXPRESS; initial catalog=inlock_games_manha; user id=sa; pwd=SQLsenha123";

        public UsuariosDomain Logar(UsuariosDomain UserLog)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectPorId = "select * from logar(@email, @senha)";
                con.Open();
                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(QuerySelectPorId, con))
                {
                    cmd.Parameters.AddWithValue("@email", UserLog.Email);
                    cmd.Parameters.AddWithValue("@senha", UserLog.Senha);
                    leitor = cmd.ExecuteReader();
                    if (leitor.Read())
                    {
                        UsuariosDomain user = new UsuariosDomain()
                        {
                            IdUsuario = Convert.ToInt32(leitor[0]),
                            IdTipo = Convert.ToInt32(leitor[1]),
                            Email = leitor[2].ToString(),

                        };

                        return user;
                    }
                    return null;
                }
            }
        }
    }
}
