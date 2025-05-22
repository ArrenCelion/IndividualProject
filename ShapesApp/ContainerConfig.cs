using Autofac;
using Commons.Modules;
using DataAccessLayer.Modules;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    public static class ContainerConfig
    {
        public static IContainer Configure(IConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            // Register Autofac modules
            builder.RegisterModule(new CommonModule());
           //builder.RegisterModule(new ServicesModule());
            builder.RegisterModule(new DataAccessModule(configuration));
            builder.RegisterType<ShapesMenuController>().AsSelf();

            return builder.Build();
        }
    }
}
