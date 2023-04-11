using MediatR;
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
