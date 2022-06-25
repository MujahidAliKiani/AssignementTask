using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Assignement.Orders
{
    internal class OrderAlreadyExistException : BusinessException
    {
        public OrderAlreadyExistException(string name)
         : base("OrderAlreadyExists")
        {
            WithData("Name", name);
        }
    }
}
