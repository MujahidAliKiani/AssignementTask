using Assignement.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Assignement.Web.Pages.Customer
{
    public class IndexModel : AssignementPageModel
    {
       public async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
