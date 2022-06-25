using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Assignement.Customers
{
    public class Customer: AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        internal Customer(
           Guid id,
           [NotNull] string name,
           [NotNull] string location
           )
           : base(id)
        {
            SetNameAndLocation(name,location);
            
        }
        //Method Use to Update Customer Values
        internal Customer ChangeNameAndLocation([NotNull] string name ,[NotNull] string location)
        {
            SetNameAndLocation(name,location);
            return this;
        }
        //Method That set values of customer Properties
        private void SetNameAndLocation([NotNull] string name, [NotNull] string location)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: CustomerConsts.MaxNameLength
                );
            Location = Check.NotNullOrWhiteSpace(
               location,
               nameof(location)
               
               );
        }
    }
}
