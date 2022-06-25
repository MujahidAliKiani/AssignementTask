using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Assignement.Orders
{
    public class Order : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public OrderStatusEnum Status { get; set; }
        public Guid CustomerId { get; set; }
        internal Order(
          Guid id,
          [NotNull] string name,
          DateTime date,
          [NotNull] string number,
          OrderTypeEnum orderType,
            Guid customerId
          )
          : base(id)
        {
            SetValues(name, date,number, orderType, customerId);

        }

        internal Order ChangeStatus(OrderStatusEnum status)
        {
            Status = status;
            return this;
        }

        internal Order UpdateOrder([NotNull] string name, DateTime date, [NotNull] string number, OrderTypeEnum oderType, Guid customerId)
        {
            SetValues(name, date, number, OrderType, customerId);
            return this;
        }

        //Method That set values of Order Properties
        private void SetValues([NotNull] string name,DateTime date, [NotNull] string number,OrderTypeEnum oderType,Guid customerId)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: OrderConsts.MaxNameLength
                );
            Number = Check.NotNullOrWhiteSpace(
               number,
               nameof(number)
                    );
            Date = date;
            OrderType= oderType;
            Status = OrderStatusEnum.Draft;
            CustomerId= customerId;
        }

    }
}
