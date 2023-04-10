using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;

namespace OrderManagement.Models.OrderItems
{
    public class OrderItemViewModel
    {
        public OrderItemTableVm OrderItemTableVm { get; set; }

        /// <summary>
        /// Action Method
        /// </summary>
        public string Action { get; set; } = "Create";

        /// <summary>
        /// UI theme
        /// </summary>
        public string Theme { get; set; } = "primary";

        /// <summary>
        /// UI input enabled flag
        /// </summary>
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Delete button enabled
        /// </summary>
        public bool AllowDelete { get; set; } = false;
    }
}
