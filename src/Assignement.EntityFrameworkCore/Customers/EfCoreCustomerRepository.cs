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

namespace Assignement.Customers
{
    public class EfCoreCustomerRepository : EfCoreRepository<AssignementDbContext, Customer, Guid>,
           ICustomerRepository
    {
        public EfCoreCustomerRepository(
            IDbContextProvider<AssignementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(string filterText = null, CancellationToken cancellationToken = default)
        {
            var query =  await GetQueryableAsync();
            query = ApplyFilter(query, filterText);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        public async Task<List<Customer>> GetListAsync(
            string filterText = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0, 
            string sorting = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText);
          
            query = query.OrderByDescending(x=>x.Id);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }
        protected virtual IQueryable<Customer> ApplyFilter(
           IQueryable<Customer> query,
           string filterText
          )
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.Location.Contains(filterText));
                   
        }
    }
}
