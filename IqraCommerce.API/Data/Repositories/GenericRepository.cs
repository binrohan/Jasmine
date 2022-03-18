using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;
using static IqraCommerce.API.Data.IRepositories.IGenericRepository;

namespace IqraCommerce.API.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync() 
        {
            return await _context.Set<T>().Where(c => !c.IsDeleted).ToListAsync();
        }

        public IQueryable<T> Queryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}