using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Entrevista
    {
        public int Id { get; set; }

        [DisplayName("Pet")]
        [ForeignKey("Pet")]
        public int IdPet { get; set; }
        public virtual Pet Pet { get; set; }

        [DisplayName("Adotante")]
        [ForeignKey("Adotante")]
        public int IdAdotante { get; set; }

        public virtual Adotante Adotante { get; set; }

        public DateTime Data { get; set; }

    }
}
