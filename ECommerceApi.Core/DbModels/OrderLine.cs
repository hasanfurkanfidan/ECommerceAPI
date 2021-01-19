using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Core.DbModels
{
    public class OrderLine:BaseEntity
    {
        /// <summary>
        /// adet
        /// </summary>
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public Sku Sku { get; set; }
        public int SkuId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
