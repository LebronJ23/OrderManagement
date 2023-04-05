using MediatR;
using OM.Application.Interfaces;
using OM.Application.Orders.Commands.Create;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OM.Application.OrderItems.Commands.Create
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, int>
    {
        private readonly IOrdersDbContext _dbContext;

        public CreateOrderItemCommandHandler(IOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit,
                OrderId = request.OrderId,
            };

            await _dbContext.OrderItems.AddAsync(orderItem, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return orderItem.Id;
        }
    }
}
