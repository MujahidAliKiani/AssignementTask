using Assignement.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Assignement.Web.Pages.Customer
{
    public class CreateModalModel : AssignementPageModel
    {
        [BindProperty]
        public CustomerCreateDto Customer { get; set; }

        private readonly ICustomerAppService _customerAppService;

        public CreateModalModel(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        public void OnGet()
        {
            Customer = new CustomerCreateDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _customerAppService.CreateAsync(Customer);
            return NoContent();
        }
    }
}
