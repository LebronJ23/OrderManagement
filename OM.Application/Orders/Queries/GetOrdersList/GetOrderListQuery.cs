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
        public FiltrationModel FiltrationModel { get; set; }
    }
}
