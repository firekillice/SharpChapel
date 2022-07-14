using Microsoft.Extensions.Configuration;
using NuGet.Configuration;

namespace Tower
{
    public static class Configure
    {
        public static void HelloConfigure()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
            Console.WriteLine(config.GetRequiredSection("Settings")["region"]);
        }
    }
}
