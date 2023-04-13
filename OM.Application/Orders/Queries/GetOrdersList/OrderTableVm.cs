using AutoMapper;
using OM.Application.Common.Mappings;
using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;
using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Providers.Queries;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrdersList
{
    public class OrderTableVm : IMapWith<Order>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public ProviderVm Provider { get; set; }
        public IEnumerable<OrderItemTableVm> OrderItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderTableVm>();
        }
    }
}
