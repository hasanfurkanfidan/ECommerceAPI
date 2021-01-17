using ECommerceApi.Core.DbModels;
using ECommerceApi.Core.Interfaces;
using ECommerceApi.Infastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Infastructure.Implements
{
    public class ProductBrandRepository:EfGenericRepository<ProductBrand>,IProductBrandRepository
    {
        public ProductBrandRepository(StoreContext storeContext):base(storeContext)
        {
                
        }
    }
}
