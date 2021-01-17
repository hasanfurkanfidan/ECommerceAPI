using ECommerceApi.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Core.Interfaces
{
    public interface IProductRepository
    {
        
        Task<List<Product>> GetProductsAsync();
        Task<List<ProductBrand>> GetProductBrandsAsync();
        Task<List<ProductType>> GetProductTypesAsync();

        Task<Product> GetProductByIdAsync(int id);
    }
}
