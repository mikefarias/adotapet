using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Service.Interfaces;
using Service.Notificacoes;
using System;
using System.IO;

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

        protected bool UploadArquivo(string arquivo, string nomeImagem)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                Notificar("Imagem não informada!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/pets", nomeImagem);

            if (System.IO.File.Exists(filePath))
            {
                Notificar("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
        protected string ObterImagemBase64(string nomeImagem)
        {
            if (string.IsNullOrEmpty(nomeImagem))
            {
                Notificar("Imagem não informada.");
                return "";
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/pets", nomeImagem);

            if (!System.IO.File.Exists(filePath))
            {
                Notificar("Não existe uma imagem com este nome!");
                return "";
            }

            var imageDataByteArray = System.IO.File.ReadAllBytes(filePath);
            var imagemBase64 = Convert.ToBase64String(imageDataByteArray);

            return imagemBase64;
        }

        protected bool ExcluirImagemDiretorio(string nomeImagem) 
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/pets", nomeImagem);
            System.IO.File.Delete(filePath);
            return true;
        }
    }
}
