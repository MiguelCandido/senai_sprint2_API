using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private string stringConexao = "Data Source=LAPTOP-7R4I65FT\\SQLEXPRESS; initial catalog=inlock_games_manha; user id=sa; pwd=SQLsenha123";

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="newStudio">Dados atualizados</param>
        /// <param name="id">ID do estúdio a ser atualizado</param>
        public void Atualizar(EstudiosDomain newStudio, int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string atualizar = "UPDATE estudio SET nomeEstudio = @nomeEstudioUPDT WHERE idEstudio = @idEstudioUPDT";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(atualizar, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudioUPDT", newStudio.NomeEstudio);
                    cmd.Parameters.AddWithValue("@idEstudioUPDT", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um estúdio específico
        /// </summary>
        /// <param name="id">ID do estúdio a ser buscado</param>
        /// <returns>O estúdio encontrado</returns>
        public EstudiosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectPorId = "select * from buscarEstudio(@idEstudio)";
                con.Open();
                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(QuerySelectPorId, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", id);
                    leitor = cmd.ExecuteReader();
                    if (leitor.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain()
                        {
                            IdEstudio = Convert.ToInt32(leitor[0]),
                            NomeEstudio = leitor[1].ToString(),
                           
                        };

                        return estudio;
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// Busca um estúdio específico
        /// </summary>
        /// <param name="id">ID do estúdio a ser buscado</param>
        /// <returns>O estúdio encontrado</returns>
        public void Cadastrar(EstudiosDomain studio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO estudio(nomeEstudio) VALUES (@nomeEstudioADD)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudioADD", studio.NomeEstudio);
                  

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um estúdio específico
        /// </summary>
        /// <param name="id">ID do estúdio a ser buscado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM estudio WHERE idEstudio = @idEstudio;";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Uma lista com os estúdios encontrados</returns>
        public List<EstudiosDomain> ListarTodos()
        {
            List<EstudiosDomain> listaEstudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelecionarTudo = "select idEstudio, nomeEstudio from estudio";

                con.Open();

                SqlDataReader leitor;

                using (SqlCommand cmd = new SqlCommand(QuerySelecionarTudo, con))
                {
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain()
                        {
                            IdEstudio = Convert.ToInt32(leitor[0]),
                            NomeEstudio = leitor[1].ToString()               
                        };

                        listaEstudios.Add(estudio);
                    }
                }
                return listaEstudios;
            }
        }
    }
}
