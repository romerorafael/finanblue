using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Finanblue.Domain.Entities
{
    [Table("purchase")]
    public class Purchase
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public decimal Total { get; set; }

        [JsonIgnore]
        public List<ProductsPurchase> ProductsPurchases { get; set; } = new List<ProductsPurchase>();
        public List<Product> ? Products { get; set;} = new List<Product>();

    }

    public class PurchaseBody
    {
        public Purchase Purchase { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
 