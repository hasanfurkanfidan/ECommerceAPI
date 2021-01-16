using ECommerceApi.Core.DbModels;
using ECommerceApi.Core.Interfaces;
using ECommerceApi.Infastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Infastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product> GetProductByIdAsync(int id)
        {
            using var context = new StoreContext();
            return await context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            using var context = new StoreContext();
            return await context.Products.ToListAsync();
        }
    }
}
