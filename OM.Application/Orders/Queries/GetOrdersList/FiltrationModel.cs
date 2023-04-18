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
        public string[] Numbers { get; set; } = Array.Empty<string>();
        public DateTime StartDate { get; set; } = DateTime.Now.Truncate(TimeSpan.FromMinutes(1)).AddMonths(-1);
        public DateTime EndDate { get; set; } = DateTime.Now.Truncate(TimeSpan.FromMinutes(1));

        public string[] OrderItemNames { get; set; } = Array.Empty<string>();
        public string[] OrderItemUnits { get; set; } = Array.Empty<string>();

        public int[] FiltrationProviders { get; set; } = Array.Empty<int>();
    }
}
