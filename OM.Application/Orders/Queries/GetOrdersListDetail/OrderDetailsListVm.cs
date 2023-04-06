using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrdersListDetail
{
    public class OrderDetailsListVm
    {
        public IList<OrderDetailsVm> Orders { get; set; }
    }
}
