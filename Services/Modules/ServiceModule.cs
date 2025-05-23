using Autofac;
using DataAccessLayer;
using Services.Shapes;
using Services.Shapes.Interfaces;
using Services.Shapes.Strategies;
using Services.Shapes.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShapeService>().As<IShapeService>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<RectangleInputReader>().As<IRectangleInputReader>();
            builder.RegisterType<RectangleStrategy>().AsSelf();
            builder.RegisterType<ApplicationDbContext>().AsSelf();
        }
    }
}
