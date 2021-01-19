using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Core.DbModels
{
    public class CartLine:BaseEntity
    {
        public int Piece { get; set; }
        public List<Sku> Skus { get; set; }
        public decimal Price { get; set; }
    }
}
