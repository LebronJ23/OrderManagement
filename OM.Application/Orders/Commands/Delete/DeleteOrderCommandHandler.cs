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

namespace OM.Application.Orders.Commands.Delete
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IOrdersDbContext _dbContext;

        public DeleteOrderCommandHandler(IOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if (order == null || order.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Order), request.Id);
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return 0;
        }
    }
}
