using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApi.Core.DbModels
{
    public class Product:BaseEntity
    {
        [JsonIgnore]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
