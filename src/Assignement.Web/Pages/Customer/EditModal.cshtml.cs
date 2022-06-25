using Assignement.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Assignement.Web.Pages.Customer
{
    public class EditModalModel : AssignementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CustomerUpdateDto Customer { get; set; }

        private readonly ICustomerAppService _customerAppService;

        public EditModalModel(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        public async Task OnGetAsync()
        {
            var customerDto = await _customerAppService.GetAsync(Id);
            Customer = ObjectMapper.Map<CustomerReadDto, CustomerUpdateDto>(customerDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _customerAppService.UpdateAsync(Id, Customer);
            return NoContent();
        }
    }
}
