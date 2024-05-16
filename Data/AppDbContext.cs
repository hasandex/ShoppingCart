using Microsoft.EntityFrameworkCore;
using SoppingCart.Models;

namespace SoppingCart.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items {  get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(
                e => new {e.OrderId,e.ItemId}
                );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food"},
                new Category { Id = 2, Name = "Sweet" },
                new Category { Id = 3, Name = "Coffee" }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
