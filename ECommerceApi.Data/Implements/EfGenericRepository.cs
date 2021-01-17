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
        private readonly StoreContext _storeContext;
        public EfGenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task AddAsync(T entity)
        {
           
                await _storeContext.AddAsync(entity);
            
            
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _storeContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            using var context = new StoreContext();
            return await _storeContext.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsyn(int id)
        {
            return await _storeContext.Set<T>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            return await _storeContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetListBySortingAsync<TSort>(Expression<Func<T, bool>> expression, Expression<Func<T, TSort>> sorting)
        {
            return await _storeContext.Set<T>().Where(expression).OrderByDescending(sorting).ToListAsync();
        }

        public void Remove(T entity)
        {

            _storeContext.Remove(entity);
        }

        public async Task<int> SavechangesAsync()
        {
            var a = await _storeContext.SaveChangesAsync();
            return a;
        }

        public void Update(T entity)
        {
            _storeContext.Update(entity);
        }
    }
}
