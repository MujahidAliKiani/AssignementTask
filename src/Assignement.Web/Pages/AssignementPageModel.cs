using Assignement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Assignement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AssignementPageModel : AbpPageModel
{
    protected AssignementPageModel()
    {
        LocalizationResourceType = typeof(AssignementResource);
    }
}
