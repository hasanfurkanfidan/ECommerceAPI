using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Core.DbModels
{
    public class Sku:BaseEntity
    {
        public decimal Price { get; set; }
        public Variant Variant { get; set; }
        public int VariantId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public List<Sku> Skus { get; set; }
    }
}
