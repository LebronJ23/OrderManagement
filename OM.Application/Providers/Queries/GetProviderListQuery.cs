using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Providers.Queries
{
    public class GetProviderListQuery : IRequest<ProviderListVm>
    {
    }
}
