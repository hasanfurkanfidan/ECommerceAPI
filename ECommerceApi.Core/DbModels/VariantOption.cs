using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Core.DbModels
{
    public class VariantOption:BaseEntity
    {
        public string Description { get; set; }
        public int VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}
