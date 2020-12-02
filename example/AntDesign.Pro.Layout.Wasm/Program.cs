using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AntDesign.Pro.Layout.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // config in the code
            // builder.Services.AddAntDesignPro(x =>
            // {
            //     x.Title = "Ant Design Pro";
            //     x.NavTheme = "light";
            //     x.Layout = "mix";
            //     x.PrimaryColor = "daybreak";
            //     x.ContentWidth = "Fluid";
            //     x.HeaderHeight = 64;
            // });

            // config with appsettings.json
            builder.Services.AddAntDesignPro(builder.Configuration);
            await builder.Build().RunAsync();
        }
    }
}
