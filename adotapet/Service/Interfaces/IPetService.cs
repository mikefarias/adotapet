using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPetService : IDisposable
    {
        void Adicionar(PetViewModel petViewModel);

        PetViewModel Atualizar(PetViewModel petViewModel);

        PetViewModel ObterPorId(int id);

        IEnumerable<PetViewModel> ObterTodos();

        IEnumerable<PetViewModel> ObterPetsPorPalavraChave(string palavraChave);

        void Remover(int id);

    }
}
