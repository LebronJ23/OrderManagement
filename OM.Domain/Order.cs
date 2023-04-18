using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OM.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public IEnumerable<OrderItem> OrderItems{ get; set; }
    }
}
