using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
