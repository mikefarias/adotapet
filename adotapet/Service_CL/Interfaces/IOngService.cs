using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOngService : IDisposable
    {
        OngViewModel Adicionar(OngViewModel ongViewModel);

        OngViewModel Atualizar(OngViewModel ongViewModel);

        OngViewModel ObterPorId(int id);

        OngViewModel ObterTodos();
        void Remover(int id);

    }
}
