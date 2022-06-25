using System;
using System.Collections.Generic;
using System.Text;

namespace Assignement.Orders
{
    public class OrderUpdateDto
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public OrderTypeEnum OrderType { get; set; }
       
        public Guid CustomerId { get; set; }


    }
}
