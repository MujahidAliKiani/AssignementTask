using Assignement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Assignement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AssignementEntityFrameworkCoreModule),
    typeof(AssignementApplicationContractsModule)
    )]
public class AssignementDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
