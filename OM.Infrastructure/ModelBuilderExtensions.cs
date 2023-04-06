using Microsoft.EntityFrameworkCore;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().HasData(
                new Provider { Id = 1, Name = "Samsung" }, 
                new Provider { Id = 2, Name = "Apple" }, 
                new Provider { Id = 3, Name = "MSI" }, 
                new Provider { Id = 4, Name = "Xiaomi" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Number = "001", Date = DateTime.Now, ProviderId = 1 },
                new Order { Id = 2, Number = "002", Date = DateTime.Now, ProviderId = 1 },
                new Order { Id = 3, Number = "003", Date = DateTime.Now, ProviderId = 2 },
                new Order { Id = 4, Number = "004", Date = DateTime.Now, ProviderId = 2 },
                new Order { Id = 5, Number = "005", Date = DateTime.Now, ProviderId = 3 },
                new Order { Id = 6, Number = "006", Date = DateTime.Now, ProviderId = 3 },
                new Order { Id = 7, Number = "007", Date = DateTime.Now, ProviderId = 4 },
                new Order { Id = 8, Number = "008", Date = DateTime.Now, ProviderId = 4 }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, Name = "1", Quantity = 3d, Unit = "unit1", OrderId = 1 },
                new OrderItem { Id = 2, Name = "2", Quantity = 3d, Unit = "unit2", OrderId = 1 },
                new OrderItem { Id = 3, Name = "3", Quantity = 3d, Unit = "unit3", OrderId = 1 },
                new OrderItem { Id = 4, Name = "1", Quantity = 3d, Unit = "unit4", OrderId = 2 },
                new OrderItem { Id = 5, Name = "2", Quantity = 3d, Unit = "unit5", OrderId = 2 },
                new OrderItem { Id = 6, Name = "3", Quantity = 3d, Unit = "unit6", OrderId = 3 }
            );
        }
    }
}
