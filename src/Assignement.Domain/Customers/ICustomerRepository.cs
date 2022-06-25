using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Assignement.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        Task<List<Customer>> GetListAsync(
                string filterText = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string sorting = null,
                  
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
           
            CancellationToken cancellationToken = default);
    }
}

