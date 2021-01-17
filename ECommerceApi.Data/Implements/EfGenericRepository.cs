using ECommerceApi.Core.DbModels;
using ECommerceApi.Core.Interfaces;
using ECommerceApi.Infastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Infastructure.Implements
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T:BaseEntity,new()
    {
        public async Task AddAsync(T entity)
        {
            using var context = new StoreContext();
            await context.AddAsync(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            using var context = new StoreContext();
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            using var context = new StoreContext();
            return await context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsyn(int id)
        {
            using var context = new StoreContext();
            return await context.Set<T>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            using var context = new StoreContext();
            return await context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetListBySortingAsync<TSort>(Expression<Func<T, bool>> expression, Expression<Func<T, TSort>> sorting)
        {
            using var context = new StoreContext();
            return await context.Set<T>().Where(expression).OrderByDescending(sorting).ToListAsync();
        }

        public void Remove(T entity)
        {
            using var context = new StoreContext();
            context.Remove(entity);
        }

        public async Task SavechangesAsync()
        {
            using var context = new StoreContext();
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            using var context = new StoreContext();
            context.Update(entity);
        }
    }
}
