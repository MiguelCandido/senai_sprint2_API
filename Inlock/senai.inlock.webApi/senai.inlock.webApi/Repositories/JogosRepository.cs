using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=LAPTOP-7R4I65FT\\SQLEXPRESS; initial catalog=inlock_games_manha; user id=sa; pwd=SQLsenha123";
        public void Atualizar(JogosDomain newGame, int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string atualizar = "UPDATE jogo SET idEstudio = @idEstudio, nomeJogo = @nomeJogo, descrição = @descrição, dataLançamento = @dataLançamento, valor = @valor  WHERE idJogo = @idJogo";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(atualizar, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", id);
                    cmd.Parameters.AddWithValue("@idEstudio", newGame.IdEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogo", newGame.Nome);
                    cmd.Parameters.AddWithValue("@descrição", newGame.Descrição);
                    cmd.Parameters.AddWithValue("@dataLançamento", newGame.dataLançamento);
                    cmd.Parameters.AddWithValue("@valor", newGame.valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectPorId = "SELECT idJogo, nomeJogo, descrição, FORMAT (dataLançamento , 'dd-MM-yyyy'),idEstudio,valor FROM jogo where idJogo = @idJogo";
                con.Open();
                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(QuerySelectPorId, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", id);
                    leitor = cmd.ExecuteReader();
                    if (leitor.Read())
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(leitor[0]),
                            Nome = leitor[1].ToString(),
                            Descrição = leitor[2].ToString(),
                            dataLançamento = Convert.ToDateTime(leitor[3]),
                            IdEstudio = Convert.ToInt32(leitor[4]),
                            valor = float.Parse(leitor[5].ToString())
                        };

                        return jogo;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(JogosDomain game)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO jogo(idEstudio,nomeJogo,descrição,dataLançamento,valor) VALUES (@idEstudioADD,@nomeJogoADD,@descriçãoADD, @dataLançamentoADD,@valorADD)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudioADD", game.IdEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogoADD", game.Nome);
                    cmd.Parameters.AddWithValue("@descriçãoADD", game.Descrição);
                    cmd.Parameters.AddWithValue("@dataLançamentoADD", game.dataLançamento);
                    cmd.Parameters.AddWithValue("@valorADD", game.valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM jogo WHERE idJogo = @idJogo;";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarTodos()
        {
            List<JogosDomain> listaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelecionarTudo = "SELECT idJogo, nomeJogo, descrição, FORMAT (dataLançamento , 'dd-MM-yyyy'),idEstudio,valor FROM jogo";

                con.Open();

                SqlDataReader leitor;

                using (SqlCommand cmd = new SqlCommand(QuerySelecionarTudo, con))
                {
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(leitor[0]),
                            Nome = leitor[1].ToString(),
                            Descrição = leitor[2].ToString(),
                            dataLançamento = Convert.ToDateTime(leitor[3]),
                            IdEstudio = Convert.ToInt32(leitor[4]),
                            valor = float.Parse(leitor[5].ToString())
                        };

                        listaJogos.Add(jogo);
                    }
                }
                return listaJogos;
            }
        }
    }
}
