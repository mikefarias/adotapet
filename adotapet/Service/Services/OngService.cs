using Domain.Repositories.Abstract;
using Service.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities;

namespace Service.Services
{

    public class OngService : BaseService, IOngService
    {

        private readonly IMapper _mapper;
        private readonly IOngRepository _ongRepository;

        public OngService(IMapper mapper, IOngRepository ongRepository, INotificador notificador) : base(notificador) 
        {
            _ongRepository = ongRepository;
            _mapper = mapper;
        }
        public void Adicionar(OngViewModel ongViewModel)
        {
            if (_ongRepository.Obter(ong => ong.Cnpj == ongViewModel.Cnpj).Any()) 
                Notificar("Já existe uma ONG com este CNPJ.");
            if (_ongRepository.Obter(ong => ong.Nome == ongViewModel.Nome).Any())
                Notificar("Já existe uma ONG com este Nome.");

            Ong ong = _mapper.Map<Ong>(ongViewModel);
             _ongRepository.Inserir(ong );
        }

        public OngViewModel Atualizar(OngViewModel ongViewModel, int id)
        {
            var ong = _ongRepository.ObterPorId(id);

            if (ong == null) return null;

            ong.Nome = ongViewModel.Nome;
            ong.Cnpj = ongViewModel.Cnpj;
            ong.Endereco = ongViewModel.Endereco;
            ong.Contato = ongViewModel.Contato;
            _ongRepository.Alterar(ong);

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
