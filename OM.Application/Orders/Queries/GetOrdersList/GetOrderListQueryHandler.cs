using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OM.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OM.Application.Orders.Queries.GetOrdersList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderTableListVm>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrdersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderTableListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var ordersList = await _dbContext
                .Orders
                .Include(order => order.OrderItems)
                .ProjectTo<OrderTableVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderTableListVm { Orders = ordersList };
        }
    }
}
