using System.Collections.Generic;

namespace OM.Application.OrderItems.Queries.GetOrderItemsListForOrder
{
    public class OrderItemListVm
    {
        public IList<OrderItemTableVm> OrderItems { get; set; }
    }
}
