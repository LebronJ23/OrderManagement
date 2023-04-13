using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Commands.Delete
{
    public class DeleteOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
