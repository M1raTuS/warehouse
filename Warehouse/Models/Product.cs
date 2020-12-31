using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int InvoiceNumber { get; set; }
        public int ProjectNumber { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

    }
}
