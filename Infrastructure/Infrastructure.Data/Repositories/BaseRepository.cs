using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.Data.Context;
using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly LoginDbContext _context;

        protected BaseRepository(LoginDbContext context)
        {
            _context = context;
        }
        
        public TEntity Add(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            _context.Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public TEntity Update(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public void Delete(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentException();
            }

            _context.Remove(obj);
            _context.SaveChanges();
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().AsNoTracking().FirstOrDefault(filter);
        }

        public List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }
    }
}