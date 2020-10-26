using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adotapet.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DateOfBirth { get; set; }

        public string Breed { get; set; }

        [ForeignKey("Ong")]
        public int IdOng { get; set; }
        public virtual Ong Ong { get; set; }

        public double Weight { get; set; }

        public bool IsAdopted { get; set; }
    }
}
