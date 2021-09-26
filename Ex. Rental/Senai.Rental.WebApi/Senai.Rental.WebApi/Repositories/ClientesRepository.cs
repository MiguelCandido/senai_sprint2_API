using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private string stringConexao = "Data Source=LAPTOP-7R4I65FT\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=SQLsenha123";

        public void Atualizar(ClienteDomain clienteNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string atualizar = "UPDATE cliente SET nomeCliente = @nomeClienteUPDT, sobrenomeCliente = @sobrenomeClienteUPDT, cpfCliente = @cpfClienteUPDT WHERE idCliente = @idClienteUPDT";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(atualizar, con))
                {
                    cmd.Parameters.AddWithValue("@nomeClienteUPDT", clienteNovo.NomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeClienteUPDT", clienteNovo.SobrenomeCliente);
                    cmd.Parameters.AddWithValue("@cpfClienteUPDT", clienteNovo.CPFCliente);
                    cmd.Parameters.AddWithValue("@idClienteUPDT", clienteNovo.IdCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectPorId = "SELECT idCliente, nomeCliente,sobrenomeCliente, cpfCliente FROM cliente where idCliente = @idCliente";
                con.Open();
                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(QuerySelectPorId, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", id);
                    leitor = cmd.ExecuteReader();
                    if (leitor.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            IdCliente = Convert.ToInt32(leitor[0]),
                            NomeCliente = leitor[1].ToString(),
                            SobrenomeCliente = leitor[2].ToString(),
                            CPFCliente = leitor[3].ToString()
                        };

                        return cliente;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain cliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO cliente(nomeCliente,sobrenomeCliente,cpfCliente) VALUES (@nomeClienteADD,@sobrenomeClienteADD,@cpfClienteADD)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@nomeClienteADD", cliente.NomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeClienteADD", cliente.SobrenomeCliente);
                    cmd.Parameters.AddWithValue("@cpfClienteADD", cliente.CPFCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM cliente WHERE idCliente = @idCliente;";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelecionarTudo = "SELECT idCliente ,nomeCliente,sobrenomeCliente, cpfCliente FROM cliente";

                con.Open();

                SqlDataReader leitor;

                using (SqlCommand cmd = new SqlCommand(QuerySelecionarTudo, con))
                {
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            IdCliente = Convert.ToInt32(leitor[0]),
                            NomeCliente = leitor[1].ToString(),
                            SobrenomeCliente = leitor[2].ToString(),
                            CPFCliente = leitor[3].ToString()
                        };

                        listaClientes.Add(cliente);
                    }
                }
                return listaClientes;
            }
        }
    }
}
