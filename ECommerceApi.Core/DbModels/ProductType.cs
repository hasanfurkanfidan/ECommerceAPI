using Newtonsoft.Json;
using System.Collections.Generic;

namespace ECommerceApi.Core.DbModels
{
    public class ProductType:BaseEntity
    {
        [JsonIgnore]
        public string Name { get; set; }
    
        public virtual List<Product> Products { get; set; }
    }
}