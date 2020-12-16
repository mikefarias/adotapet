using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEntrevistaService : IDisposable
    {
        void Adicionar(EntrevistaViewModel entrevistaViewModel);

        EntrevistaViewModel Atualizar(EntrevistaViewModel entrevistaViewModel);

        EntrevistaViewModel ObterPorId(int id);

        IEnumerable<EntrevistaViewModel> ObterTodos();

        void Remover(int id);

    }
}
