using ECommerceApi.Core.DbModels;
using ECommerceApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Infastructure.Implements
{
    public class ProductTypeRepository:EfGenericRepository<ProductType>,IProductTypeRepository
    {
    }
}
