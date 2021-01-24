using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models.Validations
{
    class PetValidation : AbstractValidator<Pet> 
    {
        public PetValidation() {

            RuleFor(o => o.Nome)
                .NotEmpty().WithMessage(MensagensErro.ValorNaoInformado);

            RuleFor(o => o.Resumo)
                .NotEmpty().WithMessage(MensagensErro.ValorNaoInformado);

            RuleFor(o => o.Ong)
                .NotEmpty().WithMessage(MensagensErro.ValorNaoInformado);

            RuleFor(o => o.Peso)
                .NotEmpty().WithMessage(MensagensErro.ValorNaoInformado);
            
            RuleFor(o => o.Raca)
                .NotEmpty().WithMessage(MensagensErro.ValorNaoInformado);

        }
    }
}
