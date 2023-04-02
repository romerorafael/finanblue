using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanblue.Domain.Entities
{
    [Table("productspurchase")]
    public class ProductsPurchase
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int PurchaseId { get; set; }

        public Product Product { get; set; }
        public Purchase Purchase { get; set;}
    }
}
