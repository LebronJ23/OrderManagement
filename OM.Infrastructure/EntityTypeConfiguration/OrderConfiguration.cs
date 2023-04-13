using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Infrastructure.EntityTypeConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.HasIndex(order => new { order.Number, order.ProviderId }).IsUnique(true);
            builder.Property(order => order.Number).IsRequired();
            builder.Property(order => order.Date).IsRequired();
            builder.Property(order => order.ProviderId).IsRequired();
        }
    }
}
