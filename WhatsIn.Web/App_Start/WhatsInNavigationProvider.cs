using Abp.Application.Navigation;
using Abp.Localization;
using WhatsIn.Authorization;

namespace WhatsIn.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class WhatsInNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "Users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
              /*  ).AddItem(
                    new MenuItemDefinition(
                        "Categories",
                        L("Categories"),
                        url: "Categories",
                        icon: "fa fa-gear",
                        requiredPermissionName: PermissionNames.Pages_Categories
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Locations",
                        L("Locations"),
                        url: "Locations",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Locations
                        ) */
                ).AddItem(
                    new MenuItemDefinition(
                        "Search",
                        L("Search"),
                        url: "Search",
                        icon: "fa fa-search" /*,
                        requiredPermissionName: PermissionNames.Pages_StoreDetail*/
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Detail",
                        L("Detail"),
                        url: "Detail",
                        icon: "fa fa-list" /*,
                        requiredPermissionName: PermissionNames.Pages_StoreDetail*/
                        )
               ).AddItem(
                    new MenuItemDefinition(
                        "Promotions",
                        L("Promotions"),
                        url: "Promotions",
                        icon: "fa fa-tags" /*,
                        requiredPermissionName: PermissionNames.Pages_Promotions */
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Galleries",
                        L("Galleries"),
                        url: "Galleries",
                        icon: "fa fa-image" /*,
                        requiredPermissionName: PermissionNames.Pages_Galleries */
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        L("About"),
                        url: "About",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WhatsInConsts.LocalizationSourceName);
        }
    }
}
