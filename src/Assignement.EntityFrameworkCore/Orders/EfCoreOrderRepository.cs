using Assignement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Assignement.Orders
{
    public class EfCoreOrderRepository : EfCoreRepository<AssignementDbContext, Order, Guid>, IOrderRepository
    {
        public EfCoreOrderRepository(
          IDbContextProvider<AssignementDbContext> dbContextProvider)
          : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(string filterText = null, CancellationToken cancellationToken = default)
        {
            var query = await GetQueryableAsync();
            query = ApplyFilter(query, filterText);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Order>> GetListAsync(string filterText = null, int maxResultCount = int.MaxValue, int skipCount = 0, string sorting = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText);

            query = query.OrderByDescending(x => x.Id);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<List<OrderWithNavigationProperties>> GetListWithNavigationPropertiesAsync(string filterText = null, string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText);
            query = query.OrderByDescending(x => x.Order.Id);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<OrderWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Order.Id == id, GetCancellationToken(cancellationToken));
        }

        protected virtual async Task<IQueryable<OrderWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from order in (await GetDbSetAsync())
                   join customer in (await GetDbContextAsync()).Customers on order.CustomerId equals customer.Id into customers
                   from customer in customers.DefaultIfEmpty()

                   select new OrderWithNavigationProperties
                   {
                       Order = order,
                       Customer = customer
                   };
        }
        protected virtual IQueryable<OrderWithNavigationProperties> ApplyFilter(
            IQueryable<OrderWithNavigationProperties> query,
            string filterText)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Order.Name.Contains(filterText) || e.Order.Number.Contains(filterText));
        }

        protected virtual IQueryable<Order> ApplyFilter(
           IQueryable<Order> query,
           string filterText
          )
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.Number.Contains(filterText));

        }

    }
}
