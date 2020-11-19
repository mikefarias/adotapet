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
        public string Name { get; set; }

        [DisplayName("Resumo")]
        public string Abstract { get; set; }

        [DisplayName("Foto")]
        public String Photo { get; set; }

        [DisplayName("Data de Nascimento")]
        public string DateOfBirth { get; set; }

        [DisplayName("Raça")]
        public string Breed { get; set; }

        [DisplayName("Ong")]
        [ForeignKey("Ong")]
        public int IdOng { get; set; }
        public virtual Ong Ong { get; set; }

        [DisplayName("Peso")]
        public double Weight { get; set; }

        [DisplayName("É Adotado? ")]
        public bool IsAdopted { get; set; }
    }
}
