using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models.Validations
{
    class OngValidation : AbstractValidator<Ong> 
    {

        public OngValidation() {

            RuleFor(o => o.Cnpj)
                .NotEmpty().WithMessage(MensagensErro.ValorNaoInformado)
                .GreaterThan(0).WithMessage(MensagensErro.ValorInvalido);

            RuleFor(o => o.Nome)
                .NotEmpty().WithMessage(MensagensErro.ValorNaoInformado);

            RuleFor(o => o.Endereco)
                .NotEmpty().WithMessage(MensagensErro.ValorNaoInformado);

            RuleFor(o => o.Contato)
                .NotEmpty().WithMessage(MensagensErro.ValorNaoInformado);
            
        }
    }
}
