using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Assignement.Orders
{
    public interface IOrderAppService:IApplicationService
    {
        Task<OrderReadDto> GetAsync(Guid id);

        Task<PagedResultDto<OrderWithNavigationPropertiesDto>> GetListAsync(GetOrderListDto input);

        Task<OrderReadDto> CreateAsync(OrderCreateDto input);

        Task UpdateAsync(Guid id, OrderUpdateDto input);

        Task DeleteAsync(Guid id);
        Task ConfirmOrderAsync(Guid Id);
        Task CancelOrderAsync(Guid Id);
        Task DispatchOrderAsync(Guid Id);
        Task ReceiveOrderAsync(Guid Id);
    }
}
