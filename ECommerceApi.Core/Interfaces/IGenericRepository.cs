using ECommerceApi.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Core.Interfaces
{
    public interface IGenericRepository<T>where T:BaseEntity,new()
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T,bool>>expression);
        Task<IReadOnlyList<T>> GetListBySortingAsync<TSort>(Expression<Func<T, bool>> expression,Expression<Func<T,TSort>>sorting);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsyn(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> SavechangesAsync();
    }
}
