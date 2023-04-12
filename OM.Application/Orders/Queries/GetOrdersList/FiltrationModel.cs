using OM.Application.Providers.Queries;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrdersList
{
    public class FiltrationModel
    {
        public string[] Numbers { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now.AddMonths(-1);
        public DateTime EndDate { get; set; } = DateTime.Now;

        public string[] OrderItemNames { get; set; }
        public string[] OrderItemUnits { get; set; }

        public int[] FiltrationProviders { get; set; }
    }
}
