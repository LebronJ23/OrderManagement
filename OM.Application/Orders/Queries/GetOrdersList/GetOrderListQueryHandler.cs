using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OM.Application.Interfaces;
using OM.Domain;
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
            var ordersList = await _dbContext
                .Orders
                .Include(order => order.OrderItems)
                .Where(order =>
                    string.IsNullOrEmpty(filtrationModel.Number)
                    ? true
                    : order.Number.Contains(filtrationModel.Number))
                .Where(order =>
                    filtrationModel.ProviderId != 0
                    ? order.ProviderId == filtrationModel.ProviderId
                    //? filtrationModel.Providers.Providers.Select(p => p.Id).Contains(order.ProviderId)
                    : true)
                .Where(order => order.Date > filtrationModel.StartDate && order.Date < filtrationModel.EndDate)
                .ProjectTo<OrderTableVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            //var filteredOrdersList = ordersList
            //    .Where(order =>
            //        string.IsNullOrEmpty(filtrationModel.Number)
            //        ? true
            //        : filtrationModel.Number.Contains(order.Number))
            //    .Where(order =>
            //        filtrationModel.Providers.Providers.Any()
            //        ? filtrationModel.Providers.Providers.Select(p => p.Id).Contains(order.ProviderId)
            //        : true)
            //    .Where(order => order.Date > filtrationModel.StartDate && order.Date < filtrationModel.EndDate)
            //    .ToList();

            
            //var dateFiltered = ordersList
            //    .Where(order => order.Date > filtrationModel.StartDate && order.Date < filtrationModel.EndDate).ToList();

            //var providerFiltered = ordersList.Where(order =>
            //        filtrationModel.Providers.Providers.Any() 
            //        ? filtrationModel.Providers.Providers.Select(p => p.Id).Contains(order.ProviderId)
            //        : true)
            //    .ToList();

            //var numberFiltered = ordersList
            //    .Where(order => string.IsNullOrEmpty(filtrationModel.Number) ? true : filtrationModel.Number.Contains(order.Number)).ToList();

            return new OrderTableListVm { Orders = ordersList, FiltrationModel = filtrationModel };
        }
    }
}
