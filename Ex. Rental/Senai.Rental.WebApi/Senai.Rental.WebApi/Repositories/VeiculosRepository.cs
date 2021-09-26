using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private string stringConexao = "Data Source=LAPTOP-7R4I65FT\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=SQLsenha123";

        public void Atualizar(VeiculoDomain veiculoNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string atualizar = "UPDATE veiculo SET idModelo = @idModeloUPDT, idEmpresa = @idEmpresaUPDT, tipoVeiculo = @tipoVeiculoUPDT, placaVeiculo = @placaVeiculoUPDT WHERE idVeiculo = @idVeiculoUPDT";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(atualizar, con))
                {
                    cmd.Parameters.AddWithValue("@idModeloUPDT", veiculoNovo.IdModelo);
                    cmd.Parameters.AddWithValue("@idEmpresaUPDT", veiculoNovo.IdEmpresa);
                    cmd.Parameters.AddWithValue("@tipoVeiculoUPDT", veiculoNovo.TipoVeiculo);
                    cmd.Parameters.AddWithValue("@placaVeiculoUPDT", veiculoNovo.PlacaVeiculo);
                    cmd.Parameters.AddWithValue("@idVeiculoUPDT", veiculoNovo.IdVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectByID = "SELECT idVeiculo, veiculo.idModelo, nomeModelo, modelo.idMarca, nomeMarca , veiculo.idEmpresa, nomeEmpresa,tipoVeiculo , placaVeiculo FROM veiculo INNER JOIN modelo on veiculo.idModelo = modelo.idModelo INNER JOIN marca on modelo.idMarca = marca.idMarca INNER JOIN empresa on veiculo.idEmpresa = empresa.idEmpresa where veiculo.idVeiculo = @idveiculo";
                con.Open();
                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(QuerySelectByID, con))
                {
                    cmd.Parameters.AddWithValue("@idveiculo", id);
                    leitor = cmd.ExecuteReader();
                    if (leitor.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(leitor[0]),
                            IdModelo = Convert.ToInt32(leitor[1]),
                            modelo = new ModeloDomain()
                            {
                                IdModelo = Convert.ToInt32(leitor[1]),
                                NomeModelo = leitor[2].ToString(),
                                IdMarca = Convert.ToInt32(leitor[3]),
                                marca = new MarcaDomain()
                                {
                                    IdMarca = Convert.ToInt32(leitor[3]),
                                    NomeMarca = leitor[4].ToString(),
                                }
                            },
                            IdEmpresa = Convert.ToInt32(leitor[5]),
                            empresa = new EmpresaDomain()
                            {
                                IdEmpresa = Convert.ToInt32(leitor[5]),
                                NomeEmpresa = leitor[6].ToString(),
                            },
                            TipoVeiculo = leitor[7].ToString(),
                            PlacaVeiculo = leitor[8].ToString(),
                        };


                        return veiculo;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain veiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO veiculo(idModelo,idEmpresa,tipoVeiculo,placaVeiculo) VALUES (@idModeloADD,@idEmpresaADD,@tipoVeiculoADD,@placaVeiculoADD)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@idModeloADD", veiculo.IdModelo);
                    cmd.Parameters.AddWithValue("@idEmpresaADD", veiculo.IdEmpresa);
                    cmd.Parameters.AddWithValue("@tipoVeiculoADD", veiculo.TipoVeiculo);
                    cmd.Parameters.AddWithValue("@placaVeiculoADD", veiculo.PlacaVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM veiculo WHERE idVeiculo = @idVeiculo;";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelecionarTudo = "SELECT idVeiculo, veiculo.idModelo, nomeModelo, modelo.idMarca, nomeMarca , veiculo.idEmpresa, nomeEmpresa,tipoVeiculo , placaVeiculo FROM veiculo INNER JOIN modelo on veiculo.idModelo = modelo.idModelo INNER JOIN marca on modelo.idMarca = marca.idMarca INNER JOIN empresa on veiculo.idEmpresa = empresa.idEmpresa";

                con.Open();

                SqlDataReader leitor;

                using (SqlCommand cmd = new SqlCommand(QuerySelecionarTudo, con))
                {
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(leitor[0]),
                            IdModelo = Convert.ToInt32(leitor[1]),
                            modelo = new ModeloDomain(){
                                IdModelo = Convert.ToInt32(leitor[1]),
                                NomeModelo = leitor[2].ToString(),
                                IdMarca = Convert.ToInt32(leitor[3]),
                                marca = new MarcaDomain()
                                {
                                    IdMarca = Convert.ToInt32(leitor[3]),
                                    NomeMarca = leitor[4].ToString(),
                                }
                            },
                            IdEmpresa = Convert.ToInt32(leitor[5]),
                            empresa = new EmpresaDomain()
                            {
                                IdEmpresa = Convert.ToInt32(leitor[5]),
                                NomeEmpresa = leitor[6].ToString(),
                            },
                            TipoVeiculo = leitor[7].ToString(),
                            PlacaVeiculo = leitor[8].ToString(),
                        };

                        listaVeiculos.Add(veiculo);
                    }
                }
                return listaVeiculos;
            }
        }
    }
}
