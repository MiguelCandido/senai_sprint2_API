using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        /// <summary>
        /// Comando para listar os alugueis
        /// </summary>
        /// <returns>Uma lista com todos os aluguéis</returns>
        List<AluguelDomain> ListarTodos();

        /// <summary>
        /// Comando para buscar um aluguel com id especifico
        /// </summary>
        /// <param name="id">ID do aluguel a ser buscado</param>
        /// <returns>Um aluguel encontrado</returns>
        AluguelDomain BuscarPorId(int id);

        /// <summary>
        /// Comando para deletar um aluguel especifico
        /// </summary>
        /// <param name="id">ID do aluguel a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Comando para criar um novo aluguel no sistema
        /// </summary>
        /// <param name="aluguel">O aluguel a ser adicionado</param>
        void Cadastrar(AluguelDomain aluguel);

        /// <summary>
        /// Comando para atualizar um aluguel existente
        /// </summary>
        /// <param name="aluguelNovo">O objeto aluguel com os novos valores</param>
        void Atualizar(AluguelDomain aluguelNovo);
    }
}
