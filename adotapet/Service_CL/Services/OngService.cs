using Domain.Repositories.Abstract;
using Domain.Repositories.Concrete;
using Service.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Service.Services
{

    public class OngService : IOngService
    {

        private readonly IMapper _mapper;
        private readonly IOngRepository _ongRepository;

        public OngService(IMapper mapper, IOngRepository ongRepository) 
        {
            _ongRepository = ongRepository;
            _mapper = mapper;
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

        public IEnumerable<OngViewModel> ObterTodos()
        {
            return _mapper.Map<List<OngViewModel>>(_ongRepository.ObterTodos());
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
