using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement.TagHelpers;
using OrchardCore.Security.Permissions;

namespace Crucible.Module
{
    public static class Module
    {
        public const string Name = "Crucible.Module";

        public static string Area() => Name.ToLower();
    }

    public class Startup : StartupBase
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddRazorRuntimeCompilation();

            services.Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AddAreaFolderRoute("PageModule", "/", "/Home");
            });

            services.AddScoped<IPermissionProvider, Permissions>();

            Conf.ResourceManagement(services);
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }

    public static class Conf
    {

        public static void ResourceManagement(IServiceCollection services)
        {
            services.AddResourceManagement();

            services.AddTagHelpers<LinkTagHelper>();
            services.AddTagHelpers<MetaTagHelper>();
            services.AddTagHelpers<ResourcesTagHelper>();
            services.AddTagHelpers<ScriptTagHelper>();
            services.AddTagHelpers<StyleTagHelper>();
        }
    }
}