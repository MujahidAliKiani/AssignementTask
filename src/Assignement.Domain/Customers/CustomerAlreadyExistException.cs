using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Assignement.Customers
{
    public class CustomerAlreadyExistException : BusinessException
    {
        public CustomerAlreadyExistException(string name)
         : base("CustomerAlreadyExists")
        {
            WithData("Name", name);
        }
    }
}
