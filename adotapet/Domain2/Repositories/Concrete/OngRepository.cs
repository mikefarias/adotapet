using Domain.Repositories.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.Concrete
{
    public class OngRepository : IOngRepository
    {
        private readonly Context _context;

        public OngRepository()
        {
        }

        OngRepository(Context context)
        {
            _context = context;
        }

        public void InserirOng(Ong ong)
        {
           _context.Add(ong);
        }
    }
}
