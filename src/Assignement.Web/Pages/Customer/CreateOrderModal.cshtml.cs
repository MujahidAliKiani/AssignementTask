using Assignement.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignement.Web.Pages.Customer
{
    public class CreateOrderModalModel : AssignementPageModel
    {
        [BindProperty]
        public OrderCreateDto Order { get; set; }
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        public List<SelectListItem> OrderTypes { get; set; }
        private readonly IOrderAppService _orderAppService;

        public CreateOrderModalModel(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        public void OnGet()
        {
            Order = new OrderCreateDto();
            OrderTypes = ((OrderTypeEnum[])Enum.GetValues(typeof(OrderTypeEnum))).Select(c => new SelectListItem() { Value = ((int)c).ToString(), Text = L[$"Enum:OrderType:{(int)c}"] }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Order.CustomerId = Id;
            await _orderAppService.CreateAsync(Order);
            return NoContent();
        }

     

    }
}

