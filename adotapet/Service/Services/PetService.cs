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
            petViewModel.Foto = Guid.NewGuid() + "_" + petViewModel.Foto;
            if (!UploadArquivo(petViewModel.ArquivoFoto, petViewModel.Foto))
            {
                Notificar("Não foi possível salvar imagem.");
                return false;
            }
            Pet pet = _mapper.Map<Pet>(petViewModel);
            bool temErro = ValidarPet(pet, petViewModel);
            if(!temErro) _petRepository.Inserir(pet );
            return temErro;
        }

        public bool Atualizar(PetViewModel petViewModel, int id)
        {
            string fotoAntiga = null;
            Pet pet = _petRepository.ObterPorId(id);
            if (petViewModel.ArquivoFoto != null)
            {
                petViewModel.Foto = Guid.NewGuid() + "_" + petViewModel.Foto;
                if (!UploadArquivo(petViewModel.ArquivoFoto, petViewModel.Foto))
                {
                    Notificar("Não foi possível salvar imagem.");
                    return false;
                }
                fotoAntiga = pet.Foto;
            }

            bool temErro = ValidarPet(pet, petViewModel);
            if (!temErro)
            {
                pet.Nome = petViewModel.Nome;
                pet.Resumo = petViewModel.Resumo;
                pet.Foto = petViewModel.Foto;
                pet.DataNascimento = petViewModel.DataNascimento;
                pet.IdOng = petViewModel.IdOng;
                pet.Raca = petViewModel.Raca;
                pet.Peso = petViewModel.Peso;
                _petRepository.Alterar(pet);
                if (fotoAntiga != null) ExcluirImagemDiretorio(fotoAntiga);
            } 
            return temErro;
        }

        public PetViewModel ObterPorId(int id)
        {
            var pet = _mapper.Map<PetViewModel>( _petRepository.ObterPorId(id)); 
            pet.ArquivoFoto = ObterImagemBase64(pet.Foto);
            return (pet);
        }

        public IEnumerable<PetViewModel> ObterTodos()
        {
            var pets = _mapper.Map<List<PetViewModel>>(_petRepository.ObterTodos());
            foreach (var pet in pets)
                pet.ArquivoFoto = ObterImagemBase64(pet.Foto);
            return pets; 
        }
        public IEnumerable<PetViewModel> ObterPetsPorPalavraChave(string palavraChave)
        {
            var pets = _mapper.Map<List<PetViewModel>>(_petRepository.ObterPetsPorPalavraChave(palavraChave));
            foreach (var pet in pets)
                pet.ArquivoFoto = ObterImagemBase64(pet.Foto);
            return pets;
        }

        public bool Remover(int id)
        {
            Pet pet = _petRepository.ObterPorId(id);
            if (pet == null)
            {
                Notificar("Pet não encontrado.");
                return false;
            }
            ExcluirImagemDiretorio(pet.Foto);
            _petRepository.Excluir(pet);
            return false;
        }
        public void Dispose() => GC.SuppressFinalize(this);
        
        private bool ValidarPet(Pet pet, PetViewModel petViewModel, bool atualizar = false)
        {
            bool temErro = false;
            if (atualizar && pet == null)
            {
                Notificar("Pet não encontrado.");
                return true;
            }
            if (_petRepository.Obter(pet => pet.Nome == petViewModel.Nome && pet.IdOng != petViewModel.IdOng) .Any())
            {
                Notificar("Já existe um Pet com este Nome.");
                temErro = true;
            }
            if (!ExecutarValidacao(new PetValidation(), pet)) temErro = true;

            return temErro;
        }
    }
}
