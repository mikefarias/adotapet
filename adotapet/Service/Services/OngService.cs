using Domain.Repositories.Abstract;
using Service.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities;
using Service.Models.Validations;

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
        public bool Adicionar(OngViewModel ongViewModel)
        {
            Ong ong = _mapper.Map<Ong>(ongViewModel);
            bool temErro = ValidarOng(ong, ongViewModel);
            if (!temErro) _ongRepository.Inserir(ong);
            return temErro;
        }

        public bool Atualizar(OngViewModel ongViewModel, int id)
        {
            var ong = _ongRepository.ObterPorId(id);
            bool temErro = ValidarOng(ong, ongViewModel, true);
            if (!temErro) 
            {
                ong.Nome = ongViewModel.Nome;
                ong.Cnpj = ongViewModel.Cnpj;
                ong.Endereco = ongViewModel.Endereco;
                ong.Contato = ongViewModel.Contato;
               _ongRepository.Alterar(ong);
            }
            return temErro;
        }

        public OngViewModel ObterPorId(int id) =>  _mapper.Map<OngViewModel>(_ongRepository.ObterPorId(id));

        public IEnumerable<OngViewModel> ObterTodos() => _mapper.Map<List<OngViewModel>>(_ongRepository.ObterTodos());

        public bool Remover(int id)
        {
            var ong = _ongRepository.ObterPorId(id);
            if (ong == null) 
            {
                Notificar("Ong não encontrada.");
                return false;
            } 
            _ongRepository.Excluir(ong);
            return true;
        }

        public void Dispose() => GC.SuppressFinalize(this);

        private bool ValidarOng(Ong ong, OngViewModel ongViewModel,  bool atualizar = false) 
        {
            bool temErro = false;
            if (atualizar && ong == null)
            {
                Notificar("Ong não encontrada.");
                return true;
            }

            if (_ongRepository.Obter(ong => ong.Cnpj == ongViewModel.Cnpj).Any())
            {
                Notificar("Já existe uma ONG com este CNPJ.");
                temErro = true;
            }

            if (_ongRepository.Obter(ong => ong.Nome == ongViewModel.Nome).Any())
            {
                Notificar("Já existe uma ONG com este Nome.");
                temErro = true;
            }

            if (!ExecutarValidacao(new OngValidation(), ong)) temErro = true;

            return temErro;
        }
    }
}
