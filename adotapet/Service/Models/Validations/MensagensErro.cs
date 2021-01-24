using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models.Validations
{
    public static class MensagensErro
    {
        public const string ValorNaoInformado = "{PropertyName} não informado.";
        public const string ValorMaiorZero = "{PropertyName} deve ser maior que zero.";
        public const string ValorInvalido = "{PropertyName} informado é inválido.";
    }
}
