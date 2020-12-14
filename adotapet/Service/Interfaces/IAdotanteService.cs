using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAdotanteService : IDisposable
    {
        void Adicionar(AdotanteViewModel adotanteViewModel);

        AdotanteViewModel Atualizar(AdotanteViewModel adotanteViewModel);

        AdotanteViewModel ObterPorId(int id);

        IEnumerable<AdotanteViewModel> ObterTodos();

        void Remover(int id);

    }
}
