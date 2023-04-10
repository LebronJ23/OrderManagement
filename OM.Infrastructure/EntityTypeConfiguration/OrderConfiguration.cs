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
            //builder.HasIndex(order => order.Id).IsUnique();
            builder.HasIndex(order => new { order.Number, order.ProviderId }).IsUnique(true);
            builder.Property(orderItem => orderItem.Number).IsRequired();
            builder.Property(orderItem => orderItem.Date).IsRequired();
            builder.Property(orderItem => orderItem.ProviderId).IsRequired();
        }
    }
}
