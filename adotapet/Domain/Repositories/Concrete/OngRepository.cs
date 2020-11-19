using Domain.Repositories.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.Concrete
{
    public class OngRepository: BaseRepository<Ong> , IOngRepository
    {

        private Context _context;

        public OngRepository(Context context) : base(context)
        {
            _context = context;
        }

        OngRepository() : base(new Context())
        { 
        }

        public void InserirOng(Ong ong)
        {
            throw new NotImplementedException();
        }
    }
}
