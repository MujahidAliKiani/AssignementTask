using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Assignement.Orders
{
    public class OrderManager:DomainService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        //Assigning Values To Order Object
        public async Task<Order> CreateAsync(
          [NotNull] string name,
          [NotNull] string number,
          DateTime date,
          OrderTypeEnum orderType,
          Guid customerId
          )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(number, nameof(number));
            //Check Order Is Already Exist Or Not
            var existing = await _orderRepository.FindAsync(x => x.Name.Equals(name));
            if (existing != null)
            {
                throw new OrderAlreadyExistException(name);
            }

            return new Order(
                GuidGenerator.Create(),
                name,
                date,
                number,
                orderType,
                customerId
            );
        }
        //Update Order Values
        public async Task UpdateAsync(
            [NotNull] Order order,
        [NotNull] string name,
        [NotNull] string number,
        DateTime date,
        OrderTypeEnum orderType,
        Guid customerId
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(number, nameof(number));
           
            order.UpdateOrder(name, date, number, orderType, customerId);
         
        }
        //Change Status of Order 
        public async Task ChangeStatus(
          [NotNull] Order order,
           OrderStatusEnum status)
        {
            Check.NotNull(order, nameof(order));
          
            order.ChangeStatus(status);
        }
    }
}
