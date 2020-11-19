using Domain.Repositorios.Abstrato;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositorios.Concreto
{
    public class OngRepositorio: BaseRepositorio<Ong> , IOngRepositorio
    {

        private Context _context;

        public OngRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        OngRepositorio() : base(new Context())
        { 
        }

        public void InserirOng(Ong ong)
        {
            throw new NotImplementedException();
        }
    }
}
