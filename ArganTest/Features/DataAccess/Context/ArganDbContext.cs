using System.Data.Entity;
using ArganTest.Features.DataAccess.Entities;

namespace ArganTest.Features.DataAccess.Context
{
    public class ArganDbContext : DbContext
    {
        public ArganDbContext() : base("DefaultConnection")
        {}

        public DbSet<TestCategory> TestCategories { get; set; }

        public DbSet<TestOrderProduct> TestOrderProducts { get; set; }

        public DbSet<TestOrder> TestOrders { get; set; }

        public DbSet<TestProduct> TestProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestProduct>()
                .HasMany(c => c.Categories)
                .WithMany(c => c.Products)
                .Map(m =>
                {
                    m.MapLeftKey("ProductId");
                    m.MapRightKey("CategoryId");
                    m.ToTable("TestProductCategories");
                });
        }
    }
}