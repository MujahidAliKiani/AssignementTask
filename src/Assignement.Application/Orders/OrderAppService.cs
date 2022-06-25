using Assignement.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Assignement.Orders
{
    [Authorize(AssignementPermissions.Orders.Default)]
    public class OrderAppService : AssignementAppService, IOrderAppService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly OrderManager _orderManager;

        public OrderAppService(IOrderRepository orderRepository, OrderManager orderManager)
        {

            _orderRepository = orderRepository;
            _orderManager = orderManager;


        }
        [Authorize(AssignementPermissions.Orders.Edit)]
        public async Task CancelOrderAsync(Guid Id)
        {
            var obj = await _orderRepository.GetAsync(Id);
            await _orderManager.ChangeStatus(obj, OrderStatusEnum.Cancel);
            await _orderRepository.UpdateAsync(obj);
        }
        [Authorize(AssignementPermissions.Orders.Edit)]
        public async Task ConfirmOrderAsync(Guid Id)
        {
            var obj = await _orderRepository.GetAsync(Id);
            await _orderManager.ChangeStatus(obj, OrderStatusEnum.Confirm);
            await _orderRepository.UpdateAsync(obj);
        }

        [Authorize(AssignementPermissions.Orders.Create)]
        public async Task<OrderReadDto> CreateAsync(OrderCreateDto input)
        {
            //Passing Value to orderManager For Assigning to order Object
            var obj = await _orderManager.CreateAsync(
              input.Name,
              input.Number,
              input.Date,
              input.OrderType,
              input.CustomerId
          );
            obj = await _orderRepository.InsertAsync(obj, autoSave: true);
            return ObjectMapper.Map<Order, OrderReadDto>(obj);

        }
        [Authorize(AssignementPermissions.Orders.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _orderRepository.DeleteAsync(id);
        }
        [Authorize(AssignementPermissions.Orders.Edit)]
        public async Task DispatchOrderAsync(Guid Id)
        {
            var obj = await _orderRepository.GetAsync(Id);
            await _orderManager.ChangeStatus(obj, OrderStatusEnum.Dispatch);
            await _orderRepository.UpdateAsync(obj);
        }

        public async Task<OrderReadDto> GetAsync(Guid id)
        {
            var obj = await _orderRepository.GetAsync(id);
            return ObjectMapper.Map<Order, OrderReadDto>(obj);
        }

        public async Task<PagedResultDto<OrderWithNavigationPropertiesDto>> GetListAsync(GetOrderListDto input)
        {
            var customers = await _orderRepository.GetListWithNavigationPropertiesAsync(
           input.Filter,
           input.Sorting,
            input.MaxResultCount,
               input.SkipCount

           

           );
            //Get Count Of Data in Table
            var totalCount = await _orderRepository.GetCountAsync(input.Filter);


            return new PagedResultDto<OrderWithNavigationPropertiesDto>(
                totalCount,
                ObjectMapper.Map<List<OrderWithNavigationProperties>, List<OrderWithNavigationPropertiesDto>>(customers)
            );
        }
        [Authorize(AssignementPermissions.Orders.Edit)]
        public async Task ReceiveOrderAsync(Guid Id)
        {
            var obj = await _orderRepository.GetAsync(Id);
            await _orderManager.ChangeStatus(obj, OrderStatusEnum.Receive);
            await _orderRepository.UpdateAsync(obj);
        }
        [Authorize(AssignementPermissions.Orders.Edit)]
        public async Task UpdateAsync(Guid id, OrderUpdateDto input)
        {
            var obj = await _orderRepository.GetAsync(id);
            //Store OrderStatus value 
            var status = obj.Status;
            //Pasing Values to CustomerManager to Updating customer Object Values
            await _orderManager.UpdateAsync(obj, input.Name,input.Number,input.Date,input.OrderType,input.CustomerId);
            //Assigning previous value of Status
            obj.Status = status;
            await _orderRepository.UpdateAsync(obj);

        }
    }
}
