using Assignement.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignement.Orders
{
    public class OrderWithNavigationPropertiesDto
    {
        public OrderReadDto Order { get; set; }
        public CustomerReadDto Customer { get; set; }

    }
}
