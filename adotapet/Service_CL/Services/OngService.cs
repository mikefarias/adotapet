using Domain.Repositories.Abstract;
using Domain.Repositories.Concrete;
using Service.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OngService : IOngService
    {
        private readonly IOngRepository _ongRepository;

        public OngService() 
        {
            _ongRepository = new OngRepository();
        }
        public OngViewModel Adicionar(OngViewModel ongViewModel)
        {
            throw new NotImplementedException();
        }

        public OngViewModel Atualizar(OngViewModel ongViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public OngViewModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public OngViewModel ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
