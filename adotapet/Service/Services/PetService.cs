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

    public class PetService : IPetService
    {

        private readonly IMapper _mapper;
        private readonly IPetRepository _petRepository;

        public PetService(IMapper mapper, IPetRepository petRepository) 
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }
        public void Adicionar(PetViewModel petViewModel)
        {
            Pet pet = _mapper.Map<Pet>(petViewModel);
             _petRepository.Inserir(pet );
        }

        public PetViewModel Atualizar(PetViewModel petViewModel)
        {
            var pet = _petRepository.Alterar(_mapper.Map<Pet>(petViewModel));

            return _mapper.Map<PetViewModel>(pet);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PetViewModel ObterPorId(int id)
        {
            return _mapper.Map<PetViewModel>(_petRepository.ObterPorId(id));
        }

        public IEnumerable<PetViewModel> ObterTodos()
        {
            return _mapper.Map<List<PetViewModel>>(_petRepository.ObterT odos());
        }

        public void Remover(int id)
        {
            Pet pet = _petRepository.ObterPorId(id);
            _petRepository.Excluir(pet);
        }
    }
}
