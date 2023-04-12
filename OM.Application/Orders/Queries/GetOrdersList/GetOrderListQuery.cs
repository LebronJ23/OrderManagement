using MediatR;
using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;
using OM.Application.Providers.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrdersList
{
    public class GetOrderListQuery : IRequest<OrderTableListVm>
    {
        public ProviderListVm Providers { get; set; }
        public OrderItemListVm OrderItems { get; set; }
        public List<OrderTableVm> Numbers { get; set; }
        //public ProviderListVm Providers { get; set; }
        public FiltrationModel FiltrationModel { get; set; }
    }
}
