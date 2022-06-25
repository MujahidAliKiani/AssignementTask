using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Assignement.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<CustomerReadDto> GetAsync(Guid id);

        Task<PagedResultDto<CustomerReadDto>> GetListAsync(GetCustomerListDto input);

        Task<CustomerReadDto> CreateAsync(CustomerCreateDto input);

        Task UpdateAsync(Guid id, CustomerUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}
