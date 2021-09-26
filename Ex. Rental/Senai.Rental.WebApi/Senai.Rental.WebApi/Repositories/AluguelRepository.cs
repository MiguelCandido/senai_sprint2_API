using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data Source=LAPTOP-7R4I65FT\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=SQLsenha123";
        public void Atualizar(AluguelDomain aluguelNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string atualizar = "UPDATE aluguel SET idVeiculo = @idVeiculoUPDT, idCliente = @idClienteUPDT, dataRetirada = @dataRetiradaUPDT, dataValidade = @dataValidadeUPDT,valorAluguel = @valorAluguelUPDT WHERE idAluguel = @idAluguelUPDT";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(atualizar, con))
                {
                    cmd.Parameters.AddWithValue("@idClienteUPDT", aluguelNovo.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculoUPDT", aluguelNovo.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataRetiradaUPDT", aluguelNovo.dataRetirada);
                    cmd.Parameters.AddWithValue("@dataValidadeUPDT", aluguelNovo.dataValidade);
                    cmd.Parameters.AddWithValue("@valorAluguelUPDT", aluguelNovo.valorAluguel);
                    cmd.Parameters.AddWithValue("@idAluguelUPDT", aluguelNovo.idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectPorId = "SELECT idAluguel,nomeCliente,sobrenomeCliente, cpfCliente, nomeModelo,placaVeiculo, dataRetirada,dataValidade FROM aluguel INNER JOIN cliente on aluguel.idCliente = cliente.idCliente INNER JOIN veiculo on aluguel.idVeiculo = veiculo.idVeiculo INNER JOIN modelo on veiculo.idModelo = modelo.idModelo where idAluguel = @idAluguel";
                con.Open();
                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(QuerySelectPorId, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", id);
                    leitor = cmd.ExecuteReader();
                    if (leitor.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(leitor[0]),
                            cliente = new ClienteDomain()
                            {
                                NomeCliente = leitor[1].ToString(),
                                SobrenomeCliente = leitor[2].ToString(),
                                CPFCliente = leitor[3].ToString()
                            },
                            veiculo = new VeiculoDomain()
                            {
                                modelo = new ModeloDomain()
                                {
                                    NomeModelo = leitor[4].ToString()
                                },
                                PlacaVeiculo = leitor[5].ToString()
                            },
                            dataRetirada = Convert.ToDateTime(leitor[6]),
                            dataValidade = Convert.ToDateTime(leitor[7])
                        };

                        return aluguel;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain aluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO aluguel(idCliente,idVeiculo,dataRetirada,dataValidade,valorAluguel) VALUES (@idClienteADD,@idVeiculoADD,@dataRetiradaADD,@dataValidadeADD,@valorAluguelADD)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@idClienteADD", aluguel.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculoADD", aluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataRetiradaADD", aluguel.dataRetirada);
                    cmd.Parameters.AddWithValue("@dataValidadeADD", aluguel.dataValidade);
                    cmd.Parameters.AddWithValue("@valorAluguelADD", aluguel.valorAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETAR
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM aluguel WHERE idAluguel = @idAluguel;";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // LISTAR TODOS
        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelecionarTudo = "SELECT idAluguel,nomeCliente,sobrenomeCliente, cpfCliente, nomeModelo,placaVeiculo, dataRetirada,dataValidade,valorAluguel FROM aluguel INNER JOIN cliente on aluguel.idCliente = cliente.idCliente INNER JOIN veiculo on aluguel.idVeiculo = veiculo.idVeiculo INNER JOIN modelo on veiculo.idModelo = modelo.idModelo";
                
                con.Open();

                SqlDataReader leitor;

                using(SqlCommand cmd = new SqlCommand(QuerySelecionarTudo, con))
                {
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(leitor[0]),
                            cliente = new ClienteDomain()
                            {
                                NomeCliente = leitor[1].ToString(),
                                SobrenomeCliente = leitor[2].ToString(),
                                CPFCliente = leitor[3].ToString()
                            },
                            veiculo = new VeiculoDomain()
                            {
                                modelo = new ModeloDomain()
                                {
                                    NomeModelo = leitor[4].ToString()
                                },
                                PlacaVeiculo = leitor[5].ToString()
                            },
                            dataRetirada = Convert.ToDateTime(leitor[6]),
                            dataValidade = Convert.ToDateTime(leitor[7]),
                            valorAluguel = leitor[8].ToString()
                        };

                        listaAlugueis.Add(aluguel);
                    }
                }
                return listaAlugueis;
            }
        }
    }
}
