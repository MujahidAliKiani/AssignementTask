using Assignement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Assignement.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AssignementController : AbpControllerBase
{
    protected AssignementController()
    {
        LocalizationResource = typeof(AssignementResource);
    }
}
