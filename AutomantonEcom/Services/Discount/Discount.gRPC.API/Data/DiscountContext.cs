using Discount.gRPC.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.API.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Coupon> coupons { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { ID = 1, Amount = 1, ProductName = "OPPO", Description = "Test" },
                new Coupon { ID = 2, Amount = 2, ProductName = "Samsung", Description = "Sam" }
                );
        }
    }
}
