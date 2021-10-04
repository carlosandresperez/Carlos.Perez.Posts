using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Posts.JsonPlaceHolderAPI.Helpers;
using System;

namespace Posts.WPF.HostBuilders
{
    public static class AddJsonPlaceHolderAPIHostBuilderExtensions
    {
        public static IHostBuilder AddJsonPlaceHolderAPI(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string apiUrl = context.Configuration.GetValue<string>("JsonPlaceHolderAPI:Url");

                services.AddHttpClient<JsonPlaceHolderAPIHttpClient>(c =>
                {
                    c.BaseAddress = new Uri(apiUrl);
                });
            });

            return host;
        }
    }
}
