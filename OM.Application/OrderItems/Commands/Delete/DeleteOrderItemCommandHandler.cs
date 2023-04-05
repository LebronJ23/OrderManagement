using MediatR;
using OM.Application.Common.Exceptions;
using OM.Application.Interfaces;
using OM.Application.Orders.Commands.Delete;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace OM.Application.OrderItems.Commands.Delete
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand>
    {
        private readonly IOrdersDbContext _dbContext;

        public DeleteOrderItemCommandHandler(IOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _dbContext.OrderItems.FirstOrDefaultAsync(oItem => oItem.Id == request.Id, cancellationToken);

            if (orderItem == null || orderItem.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Order), request.Id);
            }

            _dbContext.OrderItems.Remove(orderItem);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
