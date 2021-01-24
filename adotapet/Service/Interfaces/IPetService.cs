using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPetService : IDisposable
    {
        bool Adicionar(PetViewModel petViewModel);

        bool Atualizar(PetViewModel petViewModel, int id);

        PetViewModel ObterPorId(int id);

        IEnumerable<PetViewModel> ObterTodos();

        IEnumerable<PetViewModel> ObterPetsPorPalavraChave(string palavraChave);

        bool Remover(int id);

    }
}
