using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Posts.JsonPlaceHolderAPI.Abstractions;
using Posts.JsonPlaceHolderAPI.Services;

namespace Posts.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IPostService, PostService>();
            });

            return host;
        }
    }
}
