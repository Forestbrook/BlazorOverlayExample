using BlazorExample.Client.Abstractions;
using BlazorExample.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorExample.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // Overlay example:
            builder.Services.AddSingleton<OverlayService>();
            builder.Services.AddSingleton<IOverlayService>(sp => sp.GetRequiredService<OverlayService>());

            builder.RootComponents.Add<App>("app");
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var host = builder.Build();

            await host.RunAsync();
        }
    }
}