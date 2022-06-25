using Volo.Abp.Modularity;

namespace Assignement;

[DependsOn(
    typeof(AssignementApplicationModule),
    typeof(AssignementDomainTestModule)
    )]
public class AssignementApplicationTestModule : AbpModule
{

}
