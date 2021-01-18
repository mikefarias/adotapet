using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class EntrevistaViewModel
    {
        public int Id { get; set; }

        [DisplayName("Pet")]
        public int IdPet { get; set; }
        public virtual Pet Pet { get; set; }

        [DisplayName("Adotante")]
        public int IdAdotante { get; set; }

        public virtual Adotante Adotante { get; set; }

        [DisplayName("Data Entrevista")]
        public DateTime Data { get; set; }

    }
}
