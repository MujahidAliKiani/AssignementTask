using Assignement.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Assignement.Customers
{
    [Authorize(AssignementPermissions.Customers.Default)]
    public class CustomerAppService : AssignementAppService, ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerManager _customerManager;

        public CustomerAppService(ICustomerRepository customerRepository, CustomerManager customerManager)
        {

            _customerRepository = customerRepository;
            _customerManager = customerManager;


        }
        [Authorize(AssignementPermissions.Customers.Create)]
        public async Task<CustomerReadDto> CreateAsync(CustomerCreateDto input)
        {
            //Passing Value to CustomerManager For Assigning to customer Object
            var obj = await _customerManager.CreateAsync(
              input.Name,
              input.Location
          );
            obj = await _customerRepository.InsertAsync(obj, autoSave: true);
            return ObjectMapper.Map<Customer, CustomerReadDto>(obj);
        }
        [Authorize(AssignementPermissions.Customers.Delete)]
        public async Task DeleteAsync(Guid id)
        {

            await _customerRepository.DeleteAsync(id);
        }

        public async Task<CustomerReadDto> GetAsync(Guid id)
        {
            var obj = await _customerRepository.GetAsync(id);
            return ObjectMapper.Map<Customer, CustomerReadDto>(obj);
        }

        public async Task<PagedResultDto<CustomerReadDto>> GetListAsync(GetCustomerListDto input)
        {
          
            //Getting Data According To Pagination
            var customers = await _customerRepository.GetListAsync(
            input.Filter,
             input.MaxResultCount,
                input.SkipCount,
           
            input.Sorting

            );
            //Get Count Of Data in Table
            var totalCount = await _customerRepository.GetCountAsync(input.Filter);


            return new PagedResultDto<CustomerReadDto>(
                totalCount,
                ObjectMapper.Map<List<Customer>, List<CustomerReadDto>>(customers)
            );
        }
        [Authorize(AssignementPermissions.Customers.Edit)]
        public async Task UpdateAsync(Guid id, CustomerUpdateDto input)
        {
            var obj = await _customerRepository.GetAsync(id);
            //Pasing Values to CustomerManager to Updating customer Object Values
            await _customerManager.ChangeNameAndLocationAsync(obj, input.Name, input.Location);
            await _customerRepository.UpdateAsync(obj);
        }
    }
}
