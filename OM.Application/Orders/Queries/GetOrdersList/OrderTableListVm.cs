using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrdersList
{
    public class OrderTableListVm
    {
        public IList<OrderTableVm> Orders { get; set; }
    }
}
