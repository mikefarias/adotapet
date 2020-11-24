using Domain.Repositories.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concrete
{
    public class OngRepository : IOngRepository
    {
        private readonly Context _context;
        private readonly DbSet<Ong> DbSet;
        public OngRepository()
        {
            _context = new Context();
            DbSet = _context.Set<Ong>();
        }

        public void InserirOng(Ong ong)
        {
           _context.Add(ong);
        }

        public IEnumerable<Ong> ObterTodos()
        {
            return DbSet.ToList();
        }
    }
}
