using MediatR;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.OrderItems.Commands.Create
{
    public class CreateOrderItemCommand : IRequest<int>
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public int OrderId { get; set; }
    }
}
