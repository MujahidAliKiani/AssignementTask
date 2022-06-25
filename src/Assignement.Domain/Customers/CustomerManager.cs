using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Assignement.Customers
{
    public class CustomerManager : DomainService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        //Assigning Values To Customer Object
        public async Task<Customer> CreateAsync(
          [NotNull] string name,
          [NotNull] string location
          )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(location, nameof(location));
            //Check Customer Is Already Exist Or Not
            var existing = await _customerRepository.FindAsync(x => x.Name.Equals(name));
            if (existing != null)
            {
                throw new CustomerAlreadyExistException(name);
            }

            return new Customer(
                GuidGenerator.Create(),
                name,
                location
            );
        }
        //Change VAlues of Customer Object
        public async Task ChangeNameAndLocationAsync(
          [NotNull] Customer customer,
          [NotNull] string newName,
          [NotNull] string newLocation)
        {
            Check.NotNull(customer, nameof(customer));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));
            Check.NotNullOrWhiteSpace(newLocation, nameof(newLocation));
            //Checking Customer Name Is Alredy Exist Or Not
            var existing = await _customerRepository.FindAsync(x => x.Name.Equals(newName));
            if (existing != null && existing.Id != customer.Id)
            {
                throw new CustomerAlreadyExistException(newName);
            }

            customer.ChangeNameAndLocation(newName,newLocation);
        }
    }
}
