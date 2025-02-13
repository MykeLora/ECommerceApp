using E_commerce.Domain.Entities.Carts;
using E_commerce.Domain.Entities.Customers;
using E_commerce.Domain.Entities.Orders;
using E_commerce.Domain.Entities.Payments;
using E_commerce.Domain.Entities.Products;
using E_commerce.Domain.Entities.Status;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        #region "DbSets"

        #region "Customers"
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        #endregion

        #region "Status"
        public DbSet<Status> Statuses { get; set; }
        #endregion

        #region "Products"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        #endregion

        #region "Orders"
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        #endregion

        #region "Payments"
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Cancellation> Cancellations { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        #endregion

        #region "Carts"
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        #endregion

        #endregion

        #region "Configurations & Seed Data"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Order Relationships"
            modelBuilder.Entity<Order>()
                .HasOne(o => o.BillingAddress)
                .WithMany()
                .HasForeignKey(o => o.BillingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Cancellation)
                .WithOne(c => c.Order)
                .HasForeignKey<Cancellation>(c => c.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region "Payment Relationships"
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Refund)
                .WithOne(r => r.Payment)
                .HasForeignKey<Refund>(r => r.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region "Feedback Relationships"
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Customer)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Product)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(f => f.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.OrderItem)
                .WithMany(oi => oi.Feedbacks)
                .HasForeignKey(f => f.OrderItemId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Statuses Seed"
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Pending" },
                new Status { Id = 2, Name = "Processing" },
                new Status { Id = 3, Name = "Shipped" },
                new Status { Id = 4, Name = "Delivered" },
                new Status { Id = 5, Name = "Canceled" },
                new Status { Id = 6, Name = "Completed" },
                new Status { Id = 7, Name = "Failed" },
                new Status { Id = 8, Name = "Approved" },
                new Status { Id = 9, Name = "Rejected" },
                new Status { Id = 10, Name = "Refunded" }
            );
            #endregion

            #region "Categories Seed"
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and accessories", IsActive = true },
                new Category { Id = 2, Name = "Books", Description = "Books and magazines", IsActive = true }
            );
            #endregion

            #region "Products Seed"
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Smartphone",
                    Description = "Latest model smartphone with advanced features.",
                    Price = 699.99m,
                    StockQuantity = 50,
                    ImageUrl = "https://example.com/images/smartphone.jpg",
                    DiscountPercentage = 10,
                    CategoryId = 1,
                    IsAvailable = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Laptop",
                    Description = "High-performance laptop suitable for all your needs.",
                    Price = 999.99m,
                    StockQuantity = 30,
                    ImageUrl = "https://example.com/images/laptop.jpg",
                    DiscountPercentage = 15,
                    CategoryId = 1,
                    IsAvailable = true
                },
                new Product
                {
                    Id = 3,
                    Name = "Science Fiction Novel",
                    Description = "A thrilling science fiction novel set in the future.",
                    Price = 19.99m,
                    StockQuantity = 100,
                    ImageUrl = "https://example.com/images/scifi-novel.jpg",
                    DiscountPercentage = 5,
                    CategoryId = 2,
                    IsAvailable = true
                }
            );
            #endregion
        }
        #endregion

    }
}
