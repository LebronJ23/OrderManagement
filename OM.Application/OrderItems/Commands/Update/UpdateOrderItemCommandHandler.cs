using MediatR;
using OM.Application.Common.Exceptions;
using OM.Application.Interfaces;
using OM.Application.Orders.Commands.Update;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace OM.Application.OrderItems.Commands.Update
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand>
    {
        private readonly IOrdersDbContext _dbContext;

        public UpdateOrderItemCommandHandler(IOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _dbContext.OrderItems.FirstOrDefaultAsync(oItem => oItem.Id == request.Id, cancellationToken);

            if (orderItem == null || orderItem.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(OrderItem), request.Id);
            }

            orderItem.Name = request.Name;
            orderItem.Unit = request.Unit;
            orderItem.Quantity = request.Quantity;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
