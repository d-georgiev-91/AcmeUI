using System.Threading.Tasks;
using AcmeUI;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace AcmeUIClientSide
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddAcmeUI();

            await builder.Build().RunAsync();
        }
    }
}
