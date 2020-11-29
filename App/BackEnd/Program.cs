using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ExpendituresCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .UseContentRoot(System.IO.Directory.GetCurrentDirectory())
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls("http://0.0.0.0:80", "https://0.0.0.0:443");
                });
    }
}
