using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;
using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Providers.Queries;
using OrderManagement.Models.Orders;

namespace OrderManagement.Models.OrderItems
{
    public static class OrderItemViewModelFactory
    {
        public static OrderItemViewModel Create(OrderItemTableVm orderItemTableVm)
        {
            return new OrderItemViewModel
            {
                OrderItemTableVm = orderItemTableVm,
            };
        }

        public static OrderItemViewModel Edit(OrderItemTableVm orderItemTableVm)
        {
            return new OrderItemViewModel
            {
                OrderItemTableVm = orderItemTableVm,
                Action = "Edit",
                Theme = "warning"
            };
        }

        public static OrderItemViewModel Delete(OrderItemTableVm orderItemTableVm)
        {
            return new OrderItemViewModel
            {
                OrderItemTableVm = orderItemTableVm,
                Action = "Delete",
                Theme = "danger",
                ReadOnly = true
            };
        }
    }
}
