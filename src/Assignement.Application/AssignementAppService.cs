using System;
using System.Collections.Generic;
using System.Text;
using Assignement.Localization;
using Volo.Abp.Application.Services;

namespace Assignement;

/* Inherit your application services from this class.
 */
public abstract class AssignementAppService : ApplicationService
{
    protected AssignementAppService()
    {
        LocalizationResource = typeof(AssignementResource);
    }
}
