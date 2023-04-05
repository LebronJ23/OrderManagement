using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.OrderItems.Commands.Delete
{
    public class DeleteOrderItemCommand : IRequest
    {
        public int Id { get; set; }
    }
}
