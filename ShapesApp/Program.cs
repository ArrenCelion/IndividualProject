using Microsoft.Extensions.Configuration;

namespace ShapesApp
{
    internal class Program
    {
        public static void Main()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

            var app = new Application(configuration);
            app.Run();
        }
    }
}
