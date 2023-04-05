using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.OrderItems.Commands.Update
{
    public class UpdateOrderItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }
}
