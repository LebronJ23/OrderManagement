using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Orders.Queries.GetOrdersList;
using OM.Application.Providers.Queries;
using OM.Domain;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Models.Orders
{
    public static class OrderViewModelFactory
    {
        public static OrderViewModel Details(OrderDetailsVm orderDetailsVm)
        {
            return new OrderViewModel
            {
                OrderDetails = orderDetailsVm,
                OrderItems = orderDetailsVm.OrderItems,
                Providers = new ProviderListVm { Providers = new List<ProviderVm> { orderDetailsVm.Provider } },
                Action = "Details",
                Theme = "info",
                ReadOnly = true,
                ShowAction = false
            };
        }

        public static OrderViewModel Create(OrderDetailsVm orderDetailsVm, ProviderListVm providers)
        {
            return new OrderViewModel
            {
                OrderDetails = orderDetailsVm,
                OrderItems = orderDetailsVm.OrderItems,
                Providers = providers,
            };
        }

        public static OrderViewModel Delete(OrderDetailsVm orderDetailsVm)
        {
            return new OrderViewModel
            {
                OrderDetails = orderDetailsVm,
                OrderItems = orderDetailsVm.OrderItems,
                Providers = new ProviderListVm { Providers = new List<ProviderVm> { orderDetailsVm.Provider } },
                Action = "Delete",
                Theme = "danger",
                ReadOnly = true,
            };
        }

        public static OrderViewModel Edit(OrderDetailsVm orderDetailsVm, ProviderListVm providers)
        {
            return new OrderViewModel
            {
                OrderDetails = orderDetailsVm,
                OrderItems = orderDetailsVm.OrderItems,
                Providers = providers,
                Action = "Edit",
                Theme = "warning",
            };
        }
    }
}
