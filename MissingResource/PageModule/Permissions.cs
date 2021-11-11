using System.Collections.Generic;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace Crucible.Module
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageSettings = new Permission("Page Module", "Page Module");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(GetPermissions());
        }

        public IEnumerable<Permission> GetPermissions()
        {
            return new[] { ManageSettings };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageSettings }
                }
            };
        }
    }
}