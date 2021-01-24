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
using Service.Models.Validations;

namespace Service.Services
{

    public class PetService : BaseService, IPetService
    {

        private readonly IMapper _mapper;
        private readonly IPetRepository _petRepository;

        public PetService(IMapper mapper, IPetRepository petRepository, INotificador notificador) : base(notificador) 
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }
        public bool Adicionar(PetViewModel petViewModel)
        {
            Pet pet = _mapper.Map<Pet>(petViewModel);
            bool temErro = ValidarPet(pet, petViewModel);
            if(!temErro) _petRepository.Inserir(pet );
            return temErro;
        }

        public bool Atualizar(PetViewModel petViewModel, int id)
        {
            var pet = _petRepository.Alterar(_mapper.Map<Pet>(petViewModel));
            bool temErro = ValidarPet(pet, petViewModel);
            if (!temErro)
            {
                pet.Nome = petViewModel.Nome;
                pet.Resumo = petViewModel.Resumo;
                pet.IdOng = petViewModel.IdOng;
                pet.Ong = petViewModel.Ong;
                pet.Raca = petViewModel.Raca;
                pet.Peso = petViewModel.Peso;
            }
            return temErro;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PetViewModel ObterPorId(int id) => _mapper.Map<PetViewModel>(_petRepository.ObterPorId(id));

        public IEnumerable<PetViewModel> ObterTodos() => _mapper.Map<List<PetViewModel>>(_petRepository.ObterTodos());

        public IEnumerable<PetViewModel> ObterPetsPorPalavraChave(string palavraChave) => 
            _mapper.Map<List<PetViewModel>>(_petRepository.ObterPetsPorPalavraChave(palavraChave));

        public bool Remover(int id)
        {
            Pet pet = _petRepository.ObterPorId(id);
            if (pet == null)
            {
                Notificar("Pet não encontrado.");
                return false;
            }
            _petRepository.Excluir(pet);
            return false;
        }

        private bool ValidarPet(Pet pet, PetViewModel petViewModel, bool atualizar = false)
        {
            bool temErro = false;
            if (atualizar && pet == null)
            {
                Notificar("Pet não encontrado.");
                return true;
            }

            if (_petRepository.Obter(pet => pet.Nome == petViewModel.Nome && pet.IdOng == petViewModel.IdOng).Any())
            {
                Notificar("Já existe um Pet com este Nome.");
                temErro = true;
            }

            if (!ExecutarValidacao(new PetValidation(), pet)) temErro = true;

            return temErro;
        }
    }
}
