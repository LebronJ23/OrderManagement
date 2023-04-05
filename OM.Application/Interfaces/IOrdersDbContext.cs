using Microsoft.EntityFrameworkCore;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OM.Application.Interfaces
{
    public interface IOrdersDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Provider> Providers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
