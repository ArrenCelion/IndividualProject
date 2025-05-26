using Microsoft.Extensions.Configuration;

namespace RockPaperScissorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true)
             .Build();

            // Create an instance of the Application class and call the Run method
            var app = new Application(configuration);
            app.Run();
        }
    }
}
