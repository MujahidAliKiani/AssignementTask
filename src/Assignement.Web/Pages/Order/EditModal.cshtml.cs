using Assignement.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignement.Web.Pages.Order
{
    public class EditModalModel : AssignementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [HiddenInput]
        [BindProperty]
        public Guid CustomerId { get; set; }
       

        [BindProperty]
        public OrderUpdateDto Order { get; set; }

        private readonly IOrderAppService _orderAppService;
        public List<SelectListItem> OrderTypes { get; set; }
        public EditModalModel(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        public async Task OnGetAsync()
        {
            var orderDto = await _orderAppService.GetAsync(Id);
            OrderTypes = ((OrderTypeEnum[])Enum.GetValues(typeof(OrderTypeEnum))).Select(c => new SelectListItem() { Value = ((int)c).ToString(), Text = L[$"Enum:OrderType:{(int)c}"] }).ToList();
            Order = ObjectMapper.Map<OrderReadDto, OrderUpdateDto>(orderDto);
            CustomerId =orderDto.CustomerId;
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Order.CustomerId = CustomerId;
            await _orderAppService.UpdateAsync(Id, Order);
            return NoContent();
        }
    }
}
