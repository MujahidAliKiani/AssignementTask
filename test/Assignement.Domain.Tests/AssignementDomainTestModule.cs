using Assignement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Assignement;

[DependsOn(
    typeof(AssignementEntityFrameworkCoreTestModule)
    )]
public class AssignementDomainTestModule : AbpModule
{

}
