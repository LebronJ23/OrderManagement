using MediatR;
using System;

namespace OM.Application.Orders.Commands.Create
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int ProviderId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Number { get; set; }
    }
}
