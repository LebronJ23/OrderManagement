using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //private string name;
        //public string Name 
        //{
        //    get { return name; }
        //    set
        //    {
        //        if (OrderId != default && Order == null)
        //        {
        //            throw new ArgumentException();
        //        }
        //        else
        //        {
        //            if (value == Order.Number)
        //            {
        //                throw new InvalidOperationException();
        //            }
        //            name = value;
        //        }
        //    }
        //}
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
