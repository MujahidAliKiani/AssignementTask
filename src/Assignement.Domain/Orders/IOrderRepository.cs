using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Assignement.Orders
{
    public interface IOrderRepository: IRepository<Order,Guid>
    {
        Task<List<Order>> GetListAsync(
               string filterText = null,
           int maxResultCount = int.MaxValue,
           int skipCount = 0,
           string sorting = null,

                   CancellationToken cancellationToken = default
               );

        Task<long> GetCountAsync(
            string filterText = null,

            CancellationToken cancellationToken = default);

        Task<OrderWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default);
        Task<List<OrderWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,

            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default);
    }


}

