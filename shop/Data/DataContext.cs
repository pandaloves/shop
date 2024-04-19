using shop.Entities;
using Microsoft.EntityFrameworkCore;

namespace shop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ShopUser> ShopUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  
           modelBuilder.Entity<Product>()
                .Property(p => p.ProductQuantity)
                .HasColumnType("decimal(18,2)");

           modelBuilder.Entity<Order>()
                .Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 2)"); // Example precision and scale, adjust as needed

            modelBuilder.Entity<Product>()
                 .Property(e => e.ProductPrice)
                 .HasColumnType("decimal(18, 2)");

            // one-to-one relationship between ShopUser and Cart
            modelBuilder.Entity<ShopUser>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            // one-to-many relationship between ShopUser and Orders
            modelBuilder.Entity<ShopUser>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            // one-to-many relationship between Cart and CartItems
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            // one-to-many relationship between Order and OrderItems
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // many-to-one relationship between CartItem and Product
            //modelBuilder.Entity<CartItem>()
            //    .HasOne(ci => ci.Product)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.ProductId);

            // many-to-one relationship between OrderItem and Product
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            // one-to-one relationship between Order and Payment
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
