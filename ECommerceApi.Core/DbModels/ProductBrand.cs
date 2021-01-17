using Newtonsoft.Json;
using System.Collections.Generic;

namespace ECommerceApi.Core.DbModels
{
    public class ProductBrand:BaseEntity
    {
        [JsonIgnore]
        public string Name { get; set; }
        
        public virtual List<Product> Products { get; set; }
    }
}