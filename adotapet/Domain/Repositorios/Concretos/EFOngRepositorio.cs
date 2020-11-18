using Domain.Repositorios.Abstrato;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositorios.Concreto
{
    public class EFOngRepositorio: BaseRepositorio<Ong> , IOngRepositorio
    {

        private Context _context;

        public EFOngRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        EFOngRepositorio() : base(new Context())
        { 
        }

        public void InserirOng(Ong ong)
        {
            throw new NotImplementedException();
        }
    }
}
