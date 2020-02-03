using BlazorExample.Client.Abstractions;
using BlazorExample.Client.Services;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BlazorExample.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddSingleton<OverlayService>();
            builder.Services.AddSingleton<IOverlayService>(sp => sp.GetRequiredService<OverlayService>());

            builder.RootComponents.Add<App>("app");
            var host = builder.Build();

            await host.RunAsync();
        }
    }
}