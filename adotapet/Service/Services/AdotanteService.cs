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

    public class AdotanteService : IAdotanteService
    {

        private readonly IMapper _mapper;
        private readonly IAdotanteRepository _adotanteRepository;

        public AdotanteService(IMapper mapper, IAdotanteRepository adotanteRepository) 
        {
            _adotanteRepository = adotanteRepository;
            _mapper = mapper;
        }
        public void Adicionar(AdotanteViewModel adotanteViewModel)
        {
            Adotante adotante = _mapper.Map<Adotante>(adotanteViewModel);
            _adotanteRepository.Inserir(adotante);
        }

        public AdotanteViewModel Atualizar(AdotanteViewModel adotanteViewModel)
        {
            var adotante = _adotanteRepository.Alterar(_mapper.Map<Adotante>(adotanteViewModel));

            return _mapper.Map<AdotanteViewModel>(adotante);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AdotanteViewModel ObterPorId(int id)
        {
            return _mapper.Map<AdotanteViewModel>(_adotanteRepository.ObterPorId(id));
        }

        public IEnumerable<AdotanteViewModel> ObterTodos()
        {
            return _mapper.Map<List<AdotanteViewModel>>(_adotanteRepository.ObterTodos());
        }

        public void Remover(int id)
        {
            Adotante adotante = _adotanteRepository.ObterPorId(id);
            _adotanteRepository.Excluir(adotante);
        }
    }
}
