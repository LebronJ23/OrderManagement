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

            IQueryable<Order> queryResult = _dbContext
                .Orders
                .Include(order => order.OrderItems)
                // less or equal applied because I want to show all data after seeding
                // if only less will be applied start page after seeding will not show any data in table
                .Where(order => order.Date > filtrationModel.StartDate && order.Date <= filtrationModel.EndDate);

            if (filtrationModel.Numbers.Any())
            {
                queryResult = queryResult.Where(order => filtrationModel.Numbers.Contains(order.Number));
            }

            if (filtrationModel.FiltrationProviders.Any())
            {
                queryResult = queryResult.Where(order => filtrationModel.FiltrationProviders.Contains(order.ProviderId));
            }

            if (filtrationModel.OrderItemNames.Any())
            {
                queryResult = queryResult
                    .Where(order => 
                        order.OrderItems
                        .Where(orderItem => filtrationModel.OrderItemNames.Contains(orderItem.Name))
                        .Any()
                    );
            }

            if (filtrationModel.OrderItemUnits.Any())
            {
                queryResult = queryResult
                    .Where(order =>
                        order.OrderItems
                        .Where(orderItem => filtrationModel.OrderItemUnits.Contains(orderItem.Unit))
                        .Any()
                    );
            }

            var ordersList = await queryResult
                .ProjectTo<OrderTableVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderTableListVm 
            {
                Orders = ordersList,
                FiltrationModel = filtrationModel, 
            };
        }
    }
}
