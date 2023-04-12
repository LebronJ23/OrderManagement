using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;
using OM.Application.Providers.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrdersList
{
    public class OrderTableListVm
    {
        public IList<OrderTableVm> Orders { get; set; }

        public ProviderListVm Providers { get; set; } = new ProviderListVm { Providers = new List<ProviderVm>() };
        public OrderItemListVm OrderItems { get; set; } = new OrderItemListVm { OrderItems = new List<OrderItemTableVm>() };
        public IList<OrderTableVm> Numbers { get; set; } = new List<OrderTableVm>();

        public FiltrationModel FiltrationModel { get; set; }
    }
}
