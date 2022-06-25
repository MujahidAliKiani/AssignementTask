using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Assignement.Orders
{
    public class OrderReadDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public OrderStatusEnum Status { get; set; }
        public Guid CustomerId { get; set; }


    }
}
