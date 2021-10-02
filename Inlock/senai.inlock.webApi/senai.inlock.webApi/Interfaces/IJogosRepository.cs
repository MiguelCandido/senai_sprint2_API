using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IJogosRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista com os jogos encontrados</returns>
        List<JogosDomain> ListarTodos();
        /// <summary>
        /// Busca um jogo específico
        /// </summary>
        /// <param name="id">ID do jogo a ser buscado</param>
        /// <returns>O jogo encontrado</returns>
        JogosDomain BuscarPorId(int id);
        /// <summary>
        /// Deleta um jogo específico
        /// </summary>
        /// <param name="id">ID do jogo a ser buscado</param>
        void Deletar(int id);
        /// <summary>
        /// Cria um jogo específico
        /// </summary>
        /// <param name="game">O jogo a ser adicionado</param>
        void Cadastrar(JogosDomain game);
        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="newGame">Dados atualizados</param>
        /// <param name="id">ID do jogo a ser atualizado</param>
        void Atualizar(JogosDomain newGame, int id);
    }
}
