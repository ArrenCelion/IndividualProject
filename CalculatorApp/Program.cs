using Microsoft.Extensions.Configuration;

namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

            var app = new Application(configuration);
            app.Run();
        }
    }
}
