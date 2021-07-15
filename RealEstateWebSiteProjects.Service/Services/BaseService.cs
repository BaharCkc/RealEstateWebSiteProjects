using Microsoft.EntityFrameworkCore;
using RealEstateWebSiteProjects.Core.Entities;
using RealEstateWebSiteProjects.Data;
using RealEstateWebSiteProjects.Service.IServices;
using RealEstateWebSiteProjects.Service.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public readonly AppDbContexts _dbContext;
        public readonly IUnitOfWork _uow;
        private readonly DbSet<T> _dbSet;
        public BaseService(AppDbContexts context, IUnitOfWork uow)
        {
            _dbContext = context;
            _uow = uow;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsQueryable().Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsQueryable().Where(q => q.Id == id && !q.IsDeleted).FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable()
                           .Where(predicate)
                           .Where(x => !x.IsDeleted)
                           .OrderByDescending(x => x.RecordDate);

        }
    }
}
