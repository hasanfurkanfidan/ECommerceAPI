using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Core.DbModels
{
    public class Order : BaseEntity
    {
        public decimal Price { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
