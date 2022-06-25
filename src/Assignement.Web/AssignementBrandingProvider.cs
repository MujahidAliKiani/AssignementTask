using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Assignement.Web;

[Dependency(ReplaceServices = true)]
public class AssignementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Assignement";
}
