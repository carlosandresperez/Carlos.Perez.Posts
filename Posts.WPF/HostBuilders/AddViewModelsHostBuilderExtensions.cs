using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Posts.WPF.ViewModels;

namespace Posts.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<PostViewModel>();
            });

            return host;
        }
    }
}
