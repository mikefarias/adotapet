using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adotante
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        public string DataNascimento { get; set; }

        [DisplayName("RG")]
        public string RG{ get; set; }

        [DisplayName("CPF")]
        public string CPF { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [DisplayName("Profissão")]
        public string Profissao { get; set; }

        [DisplayName("Celular")]
        public string Celular { get; set; }
    }
}
