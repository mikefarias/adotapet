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

    public class EntrevistaService : IEntrevistaService
    {

        private readonly IMapper _mapper;
        private readonly IEntrevistaRepository _entrevistaRepository;

        public EntrevistaService(IMapper mapper, IEntrevistaRepository entrevistaRepository) 
        {
            _entrevistaRepository = entrevistaRepository;
            _mapper = mapper;
        }
        public void Adicionar(EntrevistaViewModel EntrevistaViewModel)
        {
            Entrevista Entrevista = _mapper.Map<Entrevista>(EntrevistaViewModel);
            _entrevistaRepository.Inserir(Entrevista);
        }

        public EntrevistaViewModel Atualizar(EntrevistaViewModel entrevistaViewModel)
        {
            var entrevista = _entrevistaRepository.Alterar(_mapper.Map<Entrevista>(entrevistaViewModel));

            return _mapper.Map<EntrevistaViewModel>(entrevista);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public EntrevistaViewModel ObterPorId(int id)
        {
            return _mapper.Map<EntrevistaViewModel>(_entrevistaRepository.ObterPorId(id));
        }

        public IEnumerable<EntrevistaViewModel> ObterTodos()
        {
            return _mapper.Map<List<EntrevistaViewModel>>(_entrevistaRepository.ObterTodos());
        }

        public void Remover(int id)
        {
            Entrevista entrevista = _entrevistaRepository.ObterPorId(id);
            _entrevistaRepository.Excluir(entrevista);
        }
    }
}
