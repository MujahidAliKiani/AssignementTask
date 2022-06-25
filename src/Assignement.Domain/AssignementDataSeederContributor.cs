using Assignement.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Assignement
{
    public class AssignementDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerManager _customerManager;
        public AssignementDataSeederContributor(ICustomerRepository customerRepository, CustomerManager customerManager)
        {
            _customerRepository = customerRepository;
            _customerManager = customerManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            //Add Data in Customer Table Table is Empty
            if (await _customerRepository.GetCountAsync() <= 0)
            {
                await _customerRepository.InsertAsync(
                   await _customerManager.CreateAsync("Ali","Islamabad"),
                    autoSave: true
                );

                await _customerRepository.InsertAsync(
                    await _customerManager.CreateAsync("Mujahid", "Islamabad"),
                     autoSave: true
                 );
            }
        }
    }
}
