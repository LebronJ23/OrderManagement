using OM.Application.Interfaces;
using OM.Domain;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OM.Application.Common.Exceptions;

namespace OM.Application.Orders.Commands.Update
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrdersDbContext _dbContext;

        public UpdateOrderCommandHandler(IOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if (order == null || order.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Order), request.Id);
            }

            order.ProviderId = request.ProviderId;
            order.Number = request.Number;
            order.Date = request.CreationDate;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
