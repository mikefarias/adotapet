using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Modelos
{
    public class EntrevistaModelView
    {
        public int IdPet { get; set; }
        public virtual Pet Pet { get; set; }

        public int IdAdotante { get; set; }

        public virtual Adotante Adotante { get; set; }

        public DateTime Data { get; set; }

    }
}
