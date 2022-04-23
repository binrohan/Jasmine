using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<T> where T : BaseEntity
        {
            Task<T> GetByIdAsync(Guid id);
            Task<IReadOnlyList<T>> ListAllAsync();

            public IQueryable<T> Queryable();

            // Task<T> GetEntityWithSpec(ISpecification<T> spec);
            // Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
            // Task<int> CountAsync(ISpecification<T> spec);
            
            void Add(T entity);
            void AddRange(IEnumerable<T> entities);
            void Update(T entity);
            void Delete(T entity);
        }
    }
}