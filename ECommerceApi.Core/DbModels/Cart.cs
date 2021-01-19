using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Core.DbModels
{
    public class Cart:BaseEntity
    {
        public decimal Price { get; set; }
        public decimal StockPrice { get; set; }
        public decimal CargoPrice { get; set; }
        public decimal Discount { get; set; }
        public List<CartLine> CartLines { get; set; }
    }
}
