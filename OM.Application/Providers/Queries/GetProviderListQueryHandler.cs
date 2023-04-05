using AutoMapper;
using MediatR;
using OM.Application.Interfaces;
using OM.Application.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace OM.Application.Providers.Queries
{
    public class GetProviderListQueryHandler : IRequestHandler<GetProviderListQuery, ProviderListVm>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProviderListQueryHandler(IOrdersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProviderListVm> Handle(GetProviderListQuery request, CancellationToken cancellationToken)
        {
            var providersList = await _dbContext
                .Providers
                .ProjectTo<ProviderVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProviderListVm { Providers = providersList };
        }
    }
}
