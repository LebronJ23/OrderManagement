using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;
using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Providers.Queries;
using OM.Domain;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Models.Orders
{
    /// <summary>
    /// View Model
    /// </summary>
    public class OrderViewModel
    {
        /// <summary>
        /// Order
        /// </summary>
        public OrderDetailsVm OrderDetails { get; set; }

        /// <summary>
        /// OrderItems
        /// </summary>
        public IEnumerable<OrderItemTableVm> OrderItems { get; set; } = Enumerable.Empty<OrderItemTableVm>();

        public ProviderListVm Providers { get; set; } 

        /// <summary>
        /// Action Method
        /// </summary>
        public string Action { get; set; } = "Create";

        /// <summary>
        /// UI theme
        /// </summary>
        public string Theme { get; set; } = "primary";

        /// <summary>
        /// UI enabled
        /// </summary>
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Access to action
        /// </summary>
        public bool ShowAction { get; set; } = true;
    }
}
