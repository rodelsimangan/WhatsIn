using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace WhatsIn.Authorization
{
    public class WhatsInAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));
            var categories = pages.CreateChildPermission(PermissionNames.Pages_Categories, L("Categories"));
            var locations = pages.CreateChildPermission(PermissionNames.Pages_Locations, L("Locations"));

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WhatsInConsts.LocalizationSourceName);
        }
    }
}
