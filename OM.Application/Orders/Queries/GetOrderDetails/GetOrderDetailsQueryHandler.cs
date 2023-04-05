using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OM.Application.Common.Exceptions;
using OM.Application.Interfaces;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OM.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IOrdersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbContext
                .Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if (order == null || order.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Order), request.Id);
            }

            return _mapper.Map<OrderDetailsVm>(order);
        }
    }
}
