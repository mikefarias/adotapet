using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Modelos
{
    public class OngViewModel
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("CNPJ")]
        public double Cnpj { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [DisplayName("Contato")]
        public string Contato { get; set; }
    }
}
