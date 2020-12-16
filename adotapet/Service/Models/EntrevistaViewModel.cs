using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class EntrevistaViewModel
    {
        public int Id { get; set; }

        public int IdPet { get; set; }
        public virtual Pet Pet { get; set; }

        public int IdAdotante { get; set; }

        public virtual Adotante Adotante { get; set; }

        public DateTime Data { get; set; }

    }
}
