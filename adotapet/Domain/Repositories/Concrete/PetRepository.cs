using Domain.Repositories.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concrete
{
    public class PetRepository : BaseRepository<Pet>, IPetRepository
    {
        private readonly Context _context;
        private readonly DbSet<Pet> _dbSet;
        public PetRepository(Context context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Pet>();
        }
    }
}
