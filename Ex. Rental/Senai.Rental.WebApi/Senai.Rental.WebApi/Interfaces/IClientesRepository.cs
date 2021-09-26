using Senai.Rental.WebApi.Domains;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClientesRepository
    {
        /// <summary>
        /// Comando para listar os clientes
        /// </summary>
        /// <returns>Uma lista com todos os clientes</returns>
        List<ClienteDomain> ListarTodos();

        /// <summary>
        /// Comando para buscar um cliente com id especifico
        /// </summary>
        /// <param name="id">ID do cliente a ser buscado</param>
        /// <returns>Um cliente encontrado</returns>
        ClienteDomain BuscarPorId(int id);

        /// <summary>
        /// Comando para deletar um cliente especifico
        /// </summary>
        /// <param name="id">ID do cliente a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Comando para criar um novo cliente no sistema
        /// </summary>
        /// <param name="cliente">O cliente a ser adicionado</param>
        void Cadastrar(ClienteDomain cliente);

        /// <summary>
        /// Comando para atualizar um cliente existente
        /// </summary>
        /// <param name="clienteNovo">O objeto cliente com os novos valores</param>
        void Atualizar(ClienteDomain clienteNovo);
    }
}
