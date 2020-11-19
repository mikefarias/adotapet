using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositorios.Abstrato
{
    public interface IOngRepository: IBaseRepository<Ong>
    {
        /// <summary>
        /// Insere uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        void InserirOng(Ong ong);
    }
}
