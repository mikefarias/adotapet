using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOngService : IDisposable
    {
        void Adicionar(OngViewModel ongViewModel);

        OngViewModel Atualizar(OngViewModel ongViewModel, int id);

        OngViewModel ObterPorId(int id);

        IEnumerable<OngViewModel> ObterTodos();

        void Remover(int id);

    }
}
