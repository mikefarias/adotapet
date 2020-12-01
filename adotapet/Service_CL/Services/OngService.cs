using Domain.Repositories.Abstract;
using Domain.Repositories.Concrete;
using Service.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;

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
        public void Adicionar(OngViewModel ongViewModel)
        {
            Ong ong = _mapper.Map<Ong>(ongViewModel);
             _ongRepository.Inserir(ong );
        }

        public OngViewModel Atualizar(OngViewModel ongViewModel)
        {
            var ong = _ongRepository.Alterar(_mapper.Map<Ong>(ongViewModel));

            return _mapper.Map<OngViewModel>(ong);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public OngViewModel ObterPorId(int id)
        {
            return _mapper.Map<OngViewModel>(_ongRepository.ObterPorId(id));
        }

        public IEnumerable<OngViewModel> ObterTodos()
        {
            return _mapper.Map<List<OngViewModel>>(_ongRepository.ObterTodos());
        }

        public void Remover(int id)
        {
            Ong ong = _ongRepository.ObterPorId(id);
            _ongRepository.Excluir(ong);
        }
    }
}
