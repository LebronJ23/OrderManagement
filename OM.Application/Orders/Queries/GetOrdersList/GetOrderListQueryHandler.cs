using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OM.Application.Interfaces;
using OM.Domain;
using System.Collections.Generic;
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
            var filtrationModel = request.FiltrationModel;
            var providerIds = filtrationModel.FiltrationProviders?.ToList() ?? new List<int>();
            var numbers = filtrationModel.Numbers?.ToList() ?? new List<string>();
            var orderItemNames = filtrationModel.OrderItemNames?.ToList() ?? new List<string>();
            var orderItemUnits = filtrationModel.OrderItemUnits?.ToList() ?? new List<string>();
            var ordersList = await _dbContext
                .Orders
                .Include(order => order.OrderItems)
                .Where(order =>
                    numbers.Any()
                    ? numbers.Contains(order.Number)
                    : true)
                .Where(order =>
                    orderItemNames.Any()
                    ? order.OrderItems.Where(oI => orderItemNames.Contains(oI.Name)).Any()
                    : true)
                .Where(order =>
                    orderItemUnits.Any()
                    ? order.OrderItems.Where(oI => orderItemUnits.Contains(oI.Unit)).Any()
                    : true)
                .Where(order =>
                    providerIds.Any()
                    ? providerIds.Contains(order.ProviderId)
                    : true)
                .Where(order => order.Date > filtrationModel.StartDate && order.Date < filtrationModel.EndDate)
                .ProjectTo<OrderTableVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return new OrderTableListVm 
            {
                Orders = ordersList,
                FiltrationModel = filtrationModel, 
                Providers = request.Providers,
                OrderItems = request.OrderItems,
                Numbers = request.Numbers
            };
        }
    }
}
