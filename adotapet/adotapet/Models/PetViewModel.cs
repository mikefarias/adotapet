﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adotapet.Models
{
    public class PetViewModel
    {
        public string Name { get; set; }

        public string Abstract { get; set; }

        public IFormFile Photo { get; set; }

        public string DateOfBirth { get; set; }

        public string Breed { get; set; }

        public int IdOng { get; set; }
        public virtual Ong Ong { get; set; }

        public double Weight { get; set; }

    }
}
