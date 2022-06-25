using System.Threading.Tasks;
using Assignement.Localization;
using Assignement.MultiTenancy;
using Assignement.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Assignement.Web.Menus;

public class AssignementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AssignementResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AssignementMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )

        );
        if (await context.IsGrantedAsync(AssignementPermissions.Customers.Default))
        {
            context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                AssignementMenus.Customer,
                l["Menu:Customers"],
                "~/customer",
                icon: "fas fa-user",
                order: 1
            )

        );
        }
        if (await context.IsGrantedAsync(AssignementPermissions.Orders.Default))
        {
            context.Menu.Items.Insert(
      2,
      new ApplicationMenuItem(
          AssignementMenus.Order,
          l["Menu:Orders"],
          "~/order",
          icon: "fa fa-cart-plus",
          order: 2
      )

  );
        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
