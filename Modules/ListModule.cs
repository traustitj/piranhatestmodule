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
        public string Author => "Trausti Thor Johannsson";

        /// <summary>
        /// Gets the module name
        /// </summary>
        public string Name => "ListModule";

        /// <summary>
        /// Gets the module version
        /// </summary>
        public string Version => Utils.GetAssemblyVersion(GetType().Assembly);

        /// <summary>
        /// Gets the module description
        /// </summary>
        public string Description => "Small list module for Piranha CMS";

        /// <summary>
        /// Gets the module package url
        /// </summary>
        public string PackageUrl => "";

        /// <summary>
        /// Gets the module icon url
        /// </summary>
        public string IconUrl => "http://piranhacms.org/assets/twitter-shield.png";

        public void Init()
        {
            // Register permissions
            foreach (var permission in _permissions)
            {
                App.Permissions["ListModule"].Add(permission);
            }
            Menu.Items.Insert(2, new MenuItem
            {
                InternalId = "ListModule",
                Name = "List Manager",
                Css = "fas fa-fish"
            });

                // Add manager menu items
                Menu.Items["ListModule"].Items.Add(new MenuItem
                {
                    InternalId = "ListModule",
                    Name = "List module",
                    Route = "~/manager/ListModule",
                    Policy = Permissions.ListModule,
                    Css = "fas fa-box"
                });
        }
    }
}