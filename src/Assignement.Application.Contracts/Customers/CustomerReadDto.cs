using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Assignement.Customers
{
    public class CustomerReadDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Location { get; set; }

    }
}
