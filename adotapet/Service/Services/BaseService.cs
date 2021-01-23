using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Service.Interfaces;
using Service.Notificacoes;

namespace Service.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador) 
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult) 
        {
            foreach (var erro in validationResult.Errors) {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem) => _notificador.Handle(new Notificacao(mensagem));

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entidade
        {
            var validador = validacao.Validate(entidade);
            if (validador.IsValid) return true;
            Notificar(validador);
            return false;
        }
    }
}
