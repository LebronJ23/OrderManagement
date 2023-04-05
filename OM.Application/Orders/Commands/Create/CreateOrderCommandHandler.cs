using MediatR;
using OM.Application.Interfaces;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OM.Application.Orders.Commands.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrdersDbContext _dbContext;

        public CreateOrderCommandHandler(IOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Number = request.Number,
                Date = request.CreationDate,
                ProviderId = request.ProviderId,
            };

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
