using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adotapet.Models
{
    public class Adotante
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string DataNascimento { get; set; }
        public string RG{ get; set; }

        public string CPF { get; set; }

        public string Endereco { get; set; }

        public string Profissao { get; set; }

        public string Celular { get; set; }
    }
}
