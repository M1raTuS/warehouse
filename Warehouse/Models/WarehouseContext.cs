using System.Data.Entity;

namespace Warehouse.Models
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext() : base("WarehouseConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
