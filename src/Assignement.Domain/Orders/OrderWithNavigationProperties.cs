using Assignement.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement.Orders
{
    public class OrderWithNavigationProperties
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }


    }
}
