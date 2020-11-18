using Domain.Repositorios.Abstrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositorios.Concreto
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {

        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepositorio(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
            //this.context.Configuration.LazyLoadingEnabled = false;
        }

        public BaseRepositorio() 
        { 
        }

        public void Alterar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Inserir(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity ObterPorId(int id, List<string> includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ObterTodos(params string[] includes)
        {
            throw new NotImplementedException();
        }

        public int Salvar()
        {
            throw new NotImplementedException();
        }
    }
}
