using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AntDesign.ProLayout.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();

            // config in the code
            // builder.Services.Configure<ProSettings>(x =>
            // {
            //     x.Title = "Ant Design Pro";
            //     x.NavTheme = "light";
            //     x.Layout = "mix";
            //     x.PrimaryColor = "daybreak";
            //     x.ContentWidth = "Fluid";
            //     x.HeaderHeight = 64;
            // });

            // config with appsettings.json
            var config = builder.Configuration.GetSection("ProSettings");
            builder.Services.Configure<ProSettings>(config);
            await builder.Build().RunAsync();
        }
    }
}