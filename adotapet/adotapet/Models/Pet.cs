using System;
using System.Collections.Generic;
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

        public Ong Ong { get; set; }

        public double Weight { get; set; }

        public bool IsAdopted { get; set; }
    }
}
