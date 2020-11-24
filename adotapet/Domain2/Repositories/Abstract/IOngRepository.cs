using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.Abstract 
{ 
    public interface IOngRepository
    {
        /// <summary>
        /// Insere uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        void InserirOng(Ong ong);

        IEnumerable<Ong> ObterTodos();
    }
}
