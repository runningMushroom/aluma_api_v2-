using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using alumaApi.Data;

namespace alumaApi.Repositories
{
    public interface IRepoBase<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }

    public class RepoBase<T> : IRepoBase<T> where T : class
    {
        protected DefaultDbContext DatabaseContext { get; set; }

        public RepoBase(DefaultDbContext repositoryContext)
        {
            this.DatabaseContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.DatabaseContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.DatabaseContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.DatabaseContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.DatabaseContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.DatabaseContext.Set<T>().Remove(entity);
        }
    }
}