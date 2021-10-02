using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IEstudiosRepository
    {
        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Uma lista com os estúdios encontrados</returns>
        List<EstudiosDomain> ListarTodos();

        /// <summary>
        /// Busca um estúdio específico
        /// </summary>
        /// <param name="id">ID do estúdio a ser buscado</param>
        /// <returns>O estúdio encontrado</returns>
        EstudiosDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta um estúdio específico
        /// </summary>
        /// <param name="id">ID do estúdio a ser buscado</param>
        void Deletar(int id);
        /// <summary>
        /// Cria um estúdio específico
        /// </summary>
        /// <param name="studio">O estúdio a ser adicionado</param>
        void Cadastrar(EstudiosDomain studio);

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="newStudio">Dados atualizados</param>
        /// <param name="id">ID do estúdio a ser atualizado</param>
        void Atualizar(EstudiosDomain newStudio, int id);
    }
}
