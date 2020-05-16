using Piranha;
using Piranha.Extend;
using Piranha.Manager;
using Piranha.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace testmodule.Modules
{
    public class ListModule : IModule
    {
        private readonly List<PermissionItem> _permissions = new List<PermissionItem>
        {
            new PermissionItem { Name = Permissions.ListModule, Title = "List ListModule content", Category = "ListModule", IsInternal = true },
            new PermissionItem { Name = Permissions.ListModuleAdd, Title = "Add ListModule content", Category = "ListModule", IsInternal = true },
            new PermissionItem { Name = Permissions.ListModuleEdit, Title = "Edit ListModule content", Category = "ListModule", IsInternal = true },
            new PermissionItem { Name = Permissions.ListModuleDelete, Title = "Delete ListModule content", Category = "ListModule", IsInternal = true }
        };

        /// <summary>
        /// Gets the module author
        /// </summary>
        public string Author => "";

        /// <summary>
        /// Gets the module name
        /// </summary>
        public string Name => "";

        /// <summary>
        /// Gets the module version
        /// </summary>
        public string Version => Utils.GetAssemblyVersion(GetType().Assembly);

        /// <summary>
        /// Gets the module description
        /// </summary>
        public string Description => "";

        /// <summary>
        /// Gets the module package url
        /// </summary>
        public string PackageUrl => "";

        /// <summary>
        /// Gets the module icon url
        /// </summary>
        public string IconUrl => "/manager/PiranhaModule/piranha-logo.png";

        public void Init()
        {
            // Register permissions
            foreach (var permission in _permissions)
            {
                App.Permissions["ListModule"].Add(permission);
            }

            // Add manager menu items
            Menu.Items["ListModule"].Items.Add(new MenuItem
            {
                InternalId = "ListModule",
                Name = "ListModule",
                Route = "~/manager/ListModule",
                Policy = Permissions.ListModule,
                Css = "fas fa-box"
            });
        }
    }
}