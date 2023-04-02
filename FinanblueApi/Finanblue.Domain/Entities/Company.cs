using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanblue.Domain.Entities
{
    [Table("company")]
    public class Company
    {
        [Key, Required] public int Id { get; set; }
        [Required] public string Cnpj { get; set; }
        [Required] public string Name { get; set; }
        public string? Activity { get; set; }

    }
}
