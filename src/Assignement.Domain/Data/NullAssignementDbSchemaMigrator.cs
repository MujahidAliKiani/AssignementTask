using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Assignement.Data;

/* This is used if database provider does't define
 * IAssignementDbSchemaMigrator implementation.
 */
public class NullAssignementDbSchemaMigrator : IAssignementDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
