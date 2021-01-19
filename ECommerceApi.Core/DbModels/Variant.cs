using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Core.DbModels
{
    public class Variant:BaseEntity
    {
        public string ErpCode { get; set; }
        /// <summary>
        /// Like size,height
        /// </summary>
        public string Type { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<Sku> Skus { get; set; }

        public List<VariantOption> VariantOptions { get; set; }

    }
}
