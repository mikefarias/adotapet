using Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public BaseRepository() 
        { 
        }

        public void Alterar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Excluir(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Inserir(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return dbSet.Find(id);
        }

        public TEntity ObterPorId(int id, List<string> includes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return dbSet.ToList();
        }

        public int Salvar()
        {
            throw new NotImplementedException();
        }
    }
}
