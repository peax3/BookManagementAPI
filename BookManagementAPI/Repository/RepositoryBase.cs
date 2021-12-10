using BookManagementAPI.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BookManagementAPI.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryDbContext _RepositoryDbContext;

        public RepositoryBase(RepositoryDbContext repositoryDbContext)
        {
            _RepositoryDbContext = repositoryDbContext;
        }

        public void Create(T entitty)
        {
            _RepositoryDbContext.Set<T>().Add(entitty);
        }

        public void Delete(T entitty)
        {
            _RepositoryDbContext.Set<T>().Remove(entitty);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            var entities = !trackChanges ?
                           _RepositoryDbContext.Set<T>().AsNoTracking() :
                           _RepositoryDbContext.Set<T>();

            return entities;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            var entities = !trackChanges ?
                            _RepositoryDbContext.Set<T>().Where(expression).AsNoTracking() :
                            _RepositoryDbContext.Set<T>().Where(expression);

            return entities;
        }

        public void Update(T entitty)
        {
            _RepositoryDbContext.Set<T>().Update(entitty);
        }
    }
}