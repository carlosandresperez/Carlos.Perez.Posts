using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Posts.WPF.ViewModels;
using Posts.WPF.Views;

namespace Posts.WPF.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<PostView>(s => new PostView(s.GetRequiredService<PostViewModel>()));
            });

            return host;
        }
    }
}
