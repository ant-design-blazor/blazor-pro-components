using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AntDesign.Pro.Layout.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();
            builder.Services.Configure<ProSettings>(x =>
            {
                x.NavTheme = "light";
                x.Layout = "mix";
                x.PrimaryColor = "daybreak";
                x.ContentWidth = "Fluid";
                x.Title = "Ant Design Pro";
            });

            await builder.Build().RunAsync();
        }
    }
}
