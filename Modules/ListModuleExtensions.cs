using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Piranha;
using Piranha.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace testmodule.Modules
{
    public static class ListModuleExtensions
    {
        /// <summary>
        /// Adds the ListModule module.
        /// </summary>
        /// <param name="serviceBuilder"></param>
        /// <returns></returns>
        public static PiranhaServiceBuilder UseListModule(this PiranhaServiceBuilder serviceBuilder)
        {
            serviceBuilder.Services.AddListModule();

            return serviceBuilder;
        }

        /// <summary>
        /// Uses the ListModule module.
        /// </summary>
        /// <param name="applicationBuilder">The current application builder</param>
        /// <returns>The builder</returns>
        public static PiranhaApplicationBuilder UseListModule(this PiranhaApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Builder.UseListModule();

            return applicationBuilder;
        }

        /// <summary>
        /// Adds the ListModule module.
        /// </summary>
        /// <param name="services">The current service collection</param>
        /// <returns>The services</returns>
        public static IServiceCollection AddListModule(this IServiceCollection services)
        {
            // Add the ListModule module
            Piranha.App.Modules.Register<ListModule>();

            // Setup authorization policies
            services.AddAuthorization(o =>
            {
            // ListModule policies
            o.AddPolicy(Permissions.ListModule, policy =>
                {
                    policy.RequireClaim(Permissions.ListModule, Permissions.ListModule);
                });

            // ListModule add policy
            o.AddPolicy(Permissions.ListModuleAdd, policy =>
                {
                    policy.RequireClaim(Permissions.ListModule, Permissions.ListModule);
                    policy.RequireClaim(Permissions.ListModuleAdd, Permissions.ListModuleAdd);
                });

            // ListModule edit policy
            o.AddPolicy(Permissions.ListModuleEdit, policy =>
                {
                    policy.RequireClaim(Permissions.ListModule, Permissions.ListModule);
                    policy.RequireClaim(Permissions.ListModuleEdit, Permissions.ListModuleEdit);
                });

            // ListModule delete policy
            o.AddPolicy(Permissions.ListModuleDelete, policy =>
                {
                    policy.RequireClaim(Permissions.ListModule, Permissions.ListModule);
                    policy.RequireClaim(Permissions.ListModuleDelete, Permissions.ListModuleDelete);
                });
            });

            // Return the service collection
            return services;
        }

        /// <summary>
        /// Uses the ListModule.
        /// </summary>
        /// <param name="builder">The application builder</param>
        /// <returns>The builder</returns>
        public static IApplicationBuilder UseListModule(this IApplicationBuilder builder)
        {
            return builder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new EmbeddedFileProvider(typeof(ListModule).Assembly, "ListModule.assets.dist"),
                RequestPath = "/manager/ListModule"
            });
        }

        /// <summary>
        /// Static accessor to ListModule module if it is registered in the Piranha application.
        /// </summary>
        /// <param name="modules">The available modules</param>
        /// <returns>The ListModule module</returns>
        public static ListModule ListModule(this Piranha.Runtime.AppModuleList modules)
        {
            return modules.Get<ListModule>();
        }
    }
}