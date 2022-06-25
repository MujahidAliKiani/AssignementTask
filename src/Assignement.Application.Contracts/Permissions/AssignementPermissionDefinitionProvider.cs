using Assignement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Assignement.Permissions;

public class AssignementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AssignementPermissions.GroupName);
        //Define your own permissions here. Example:
        var customersPermission = myGroup.AddPermission(
    AssignementPermissions.Customers.Default, L("Permission:Customers"));

        customersPermission.AddChild(
            AssignementPermissions.Customers.Create, L("Permission:Customers.Create"));

        customersPermission.AddChild(
            AssignementPermissions.Customers.Edit, L("Permission:Customer.Edit"));

        customersPermission.AddChild(
            AssignementPermissions.Customers.Delete, L("Permission:Customer.Delete"));
        //Add Order Permission
        var ordersPermission = myGroup.AddPermission(
  AssignementPermissions.Orders.Default, L("Permission:Orders"));

        ordersPermission.AddChild(
            AssignementPermissions.Orders.Create, L("Permission:Orders.Create"));

        ordersPermission.AddChild(
            AssignementPermissions.Orders.Edit, L("Permission:Orders.Edit"));

        ordersPermission.AddChild(
            AssignementPermissions.Orders.Delete, L("Permission:Orders.Delete"));

    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AssignementResource>(name);
    }
}
