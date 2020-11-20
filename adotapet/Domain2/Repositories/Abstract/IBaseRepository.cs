using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Obtém por Id
        /// </summary>
        /// <param name="id">Chave principal</param>
        /// <returns></returns>
        TEntity ObterPorId(int id);


        TEntity ObterPorId(int id, List<string> includes);

        /// <summary>
        /// Obtém todos com os includes listados
        /// </summary>
        /// <param name="includes">Includes</param>
        /// <returns>Queryable da entity</returns>
        IQueryable<TEntity> ObterTodos(params string[] includes);

        /// <summary>
        /// Insere uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        void Inserir(TEntity entity);
        /// <summary>
        /// Altera uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        void Alterar(TEntity entity);
        /// <summary>
        /// Exclui uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        void Excluir(TEntity entity);
        /// <summary>
        /// Método que salva todas as inserções/alterações/exclusões
        /// </summary>
        /// <returns></returns>
        int Salvar();

        void Dispose();
    }

}
