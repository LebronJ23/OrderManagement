using Microsoft.EntityFrameworkCore;
using OM.Application.Interfaces;
using OM.Domain;
using OM.Infrastructure.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OM.Infrastructure
{
    public class OrdersDbContext : DbContext, IOrdersDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Provider> Providers { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemTypeConfiguration());
            
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
