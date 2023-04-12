using MediatR;
using OM.Application.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<OrderTableListVm>
    {

    }
}
