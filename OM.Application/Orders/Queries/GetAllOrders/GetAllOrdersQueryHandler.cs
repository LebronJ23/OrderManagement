using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OM.Application.Interfaces;
using OM.Application.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper.QueryableExtensions;

namespace OM.Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, OrderTableListVm>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrdersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderTableListVm> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var ordersList = await _dbContext
                .Orders
                .Include(order => order.OrderItems)
                .Include(order => order.Provider)
                .ProjectTo<OrderTableVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderTableListVm { Orders = ordersList };
        }
    }
}
