using System.Threading.Tasks;

namespace Assignement.Data;

public interface IAssignementDbSchemaMigrator
{
    Task MigrateAsync();
}
