using ECommerceApi.Core.DbModels;
using ECommerceApi.Core.Interfaces;
using ECommerceApi.Infastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Infastructure.Implements
{
    public class ProductTypeRepository:EfGenericRepository<ProductType>,IProductTypeRepository
    {
        public ProductTypeRepository(StoreContext storeContext):base(storeContext)
        {
                
        }
    }
}
