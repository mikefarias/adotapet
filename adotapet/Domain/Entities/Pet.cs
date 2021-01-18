using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Resumo")]
        public string Resumo { get; set; }

        [DisplayName("Foto")]
        public String Foto { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Raça")]
        public string Raca { get; set; }

        [DisplayName("Ong")]
        [ForeignKey("Ong")]
        public int IdOng { get; set; }
        public virtual Ong Ong { get; set; }

        [DisplayName("Peso")]
        public double Peso { get; set; }

        [DisplayName("É Adotado? ")]
        public bool Adotado { get; set; }
    }
}
