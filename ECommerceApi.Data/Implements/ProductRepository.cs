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
        public async Task<List<ProductBrand>> GetProductBrandsAsync()
        {
            using var context = new StoreContext();
            return await context.ProductBrands.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            using var context = new StoreContext();
            return await context.Products.AsNoTracking().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            using var context = new StoreContext();
            return await context.Products.Include(p=>p.ProductBrand).Include(p=>p.ProductType).ToListAsync();
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            using var context = new StoreContext();
            return await context.ProductTypes.AsNoTracking().ToListAsync();

        }
    }
}
