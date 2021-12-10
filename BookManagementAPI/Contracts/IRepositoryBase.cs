using System;
using System.Linq;
using System.Linq.Expressions;

namespace BookManagementAPI.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        void Create(T entitty);

        void Delete(T entitty);

        void Update(T entitty);
    }
}