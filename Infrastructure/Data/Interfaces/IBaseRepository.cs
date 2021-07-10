using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Infrastructure.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity FindOne(Expression<Func<TEntity, bool>> filter);
        List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
    }
}