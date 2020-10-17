using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adotapet.Models
{
    public class Ong
    {
        public int Id { get; set; }

        public string Name{ get; set; }

        public double Cnpj{ get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }


    }
}
