using Microsoft.EntityFrameworkCore;
using RencanaProduksiSoalDua.Models;

namespace RencanaProduksiSoalDua.Data
{
    public class ProductionDbContext : DbContext
    {
        public ProductionDbContext(DbContextOptions<ProductionDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductionPlan> ProductionPlanCar { get; set; }
    }
}
