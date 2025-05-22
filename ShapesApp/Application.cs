using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    public class Application
    {
        private readonly IConfiguration _config;
        private readonly IContainer _container;

        public Application(IConfiguration config)
        {
            _config = config;
            _container = ContainerConfig.Configure(config);
        }
        public void Run()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var dataInitializer = scope.Resolve<DataAccessLayer.DataInitializer>();
                dataInitializer.SeedData();

                var controller = scope.Resolve<ShapesMenuController>();
                controller.RunShapesMenu();
            }
        }
    }
}
