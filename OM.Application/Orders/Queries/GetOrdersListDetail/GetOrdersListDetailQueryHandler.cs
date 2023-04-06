using AutoMapper;
using MediatR;
using OM.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper.QueryableExtensions;
using OM.Application.Orders.Queries.GetOrderDetails;
using Microsoft.EntityFrameworkCore;

namespace OM.Application.Orders.Queries.GetOrdersListDetail
{
    public class GetOrdersListDetailQueryHandler : IRequestHandler<GetOrdersListDetailQuery, OrderDetailsListVm>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrdersListDetailQueryHandler(IOrdersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDetailsListVm> Handle(GetOrdersListDetailQuery request, CancellationToken cancellationToken)
        {
            var ordersList = await _dbContext
                .Orders
                .Include(o => o.OrderItems)
                .ProjectTo<OrderDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderDetailsListVm { Orders = ordersList };
        }
    }
}
