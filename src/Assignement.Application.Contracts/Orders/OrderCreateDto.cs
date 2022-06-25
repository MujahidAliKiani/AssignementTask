using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assignement.Orders
{
    public class OrderCreateDto
    {
        [Required]
        [StringLength(OrderConsts.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public OrderTypeEnum OrderType { get; set; }
        public Guid CustomerId { get; set; }

    }
}
