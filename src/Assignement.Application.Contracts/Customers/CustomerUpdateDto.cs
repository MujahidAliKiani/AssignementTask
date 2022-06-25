using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assignement.Customers
{
    public class CustomerUpdateDto
    {
        [Required]
        [StringLength(CustomerConsts.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
