using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculosRepository
    {
        /// <summary>
        /// Comando para listar os veiculos
        /// </summary>
        /// <returns>Uma lista com todos os veiculos</returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Comando para buscar um veiculo com id especifico
        /// </summary>
        /// <param name="id">ID do veiculo a ser buscado</param>
        /// <returns>Um veiculo encontrado</returns>
        VeiculoDomain BuscarPorId(int id);

        /// <summary>
        /// Comando para deletar um veiculo especifico
        /// </summary>
        /// <param name="id">ID do veiculo a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Comando para criar um novo veiculo no sistema
        /// </summary>
        /// <param name="veiculo">O veiculo a ser adicionado</param>
        void Cadastrar(VeiculoDomain veiculo);

        /// <summary>
        /// Comando para atualizar um veiculo existente
        /// </summary>
        /// <param name="veiculoNovo">O objeto veiculo com os novos valores</param>
        void Atualizar(VeiculoDomain veiculoNovo);
    }
}
