using AutoMapper;
using MediatR;
using OM.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OM.Application.OrderItems.Queries.GetOrderItemsListForOrder
{
    public class GetOrderItemsListQueryHandler : IRequestHandler<GetOrderItemsListQuery, OrderItemListVm>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderItemsListQueryHandler(IOrdersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderItemListVm> Handle(GetOrderItemsListQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _dbContext
                .OrderItems
                .Where(item => item.OrderId == request.OrderId)
                .ProjectTo<OrderItemTableVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderItemListVm { OrderItems = orderItems };
        }
    }
}
