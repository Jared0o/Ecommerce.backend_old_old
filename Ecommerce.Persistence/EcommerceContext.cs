using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Tax> Taxes { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductsCategories { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcommerceContext).Assembly);

            foreach(var category in CategoryDataSeed.GetCategories())
            {
                modelBuilder.Entity<Category>().HasData(category);
            }
        }
    }
}
