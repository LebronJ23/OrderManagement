﻿using OM.Application.Providers.Queries;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OM.Application.Orders.Queries.GetOrdersList
{
    public class FiltrationModel
    {
        public string Number { get; set; } = String.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now.AddMonths(-1);
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int ProviderId { get; set; }
        public ProviderListVm Providers { get; set; } = new ProviderListVm { Providers = new List<ProviderVm>() };
    }
}
