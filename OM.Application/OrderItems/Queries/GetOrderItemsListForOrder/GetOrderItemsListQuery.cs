using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.OrderItems.Queries.GetOrderItemsListForOrder
{
    public class GetOrderItemsListQuery : IRequest<OrderItemListVm>
    {
        public int OrderId { get; set; }
    }
}
