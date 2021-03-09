using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductCatalog.Models
{
    public class ProductView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
