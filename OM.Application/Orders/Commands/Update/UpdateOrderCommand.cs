using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Commands.Update
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Number { get; set; }
    }
}
