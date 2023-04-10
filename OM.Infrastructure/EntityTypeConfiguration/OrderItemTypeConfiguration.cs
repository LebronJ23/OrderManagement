using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Infrastructure.EntityTypeConfiguration
{
    public class OrderItemTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(orderItem => orderItem.Id);
            //builder.HasIndex(order => order.Id).IsUnique();
            builder.HasIndex(orderItem => new { orderItem.Name });
            builder.Property(orderItem => orderItem.Name).IsRequired();
            builder.Property(orderItem => orderItem.Quantity).IsRequired();
            builder.Property(orderItem => orderItem.Unit).IsRequired();
            //builder.HasOne(orderItem => orderItem.Order).
            //builder.HasCheckConstraint("Name", "Name <> Select Number from Order where Order.Id == ");
        }
    }
}
