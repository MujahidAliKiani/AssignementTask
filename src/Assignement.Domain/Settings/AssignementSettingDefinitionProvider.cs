using Volo.Abp.Settings;

namespace Assignement.Settings;

public class AssignementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AssignementSettings.MySetting1));
    }
}
