using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsVm>
    {
        public int Id { get; set; }
    }
}
