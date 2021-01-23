using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repositories.Abstract
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> Obter(Expression<Func<T, bool>> parametros);

        /// <summary>
        /// Obtém por Id
        /// </summary>
        /// <param name="id">Chave principal</param>
        /// <returns></returns>
        T ObterPorId(int id);

        /// <summary>
        /// Obtém todos com os includes listados
        /// </summary>
        /// <returns>Queryable da entity</returns>
        IEnumerable<T> ObterTodos();

        /// <summary>
        /// Insere uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        T Inserir(T entity);
        /// <summary>
        /// Altera uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        T Alterar(T entity);
        /// <summary>
        /// Exclui uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        void Excluir(T entity);
        /// <summary>
        /// Método que salva todas as inserções/alterações/exclusões
        /// </summary>
        /// <returns></returns>
        T Salvar(T entity);

        void Dispose();
    }

}
