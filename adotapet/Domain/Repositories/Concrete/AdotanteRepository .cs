using Domain.Repositories.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concrete
{
    public class AdotanteRepository : BaseRepository<Adotante>, IAdotanteRepository
    {
        private readonly Context _context;
        private readonly DbSet<Ong> DbSet;
        public AdotanteRepository(Context context) : base(context)
        {
            _context = context;
            DbSet = _context.Set<Ong>();
        }
    }
}
