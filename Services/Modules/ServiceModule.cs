using Autofac;
using DataAccessLayer;
using Services.RPS;
using Services.RPS.Interfaces;
using Services.RPS.UI;
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
            builder.RegisterType<InputReader>().As<IInputReader>();
            builder.RegisterType<RectangleStrategy>().AsSelf();
            builder.RegisterType<TriangleStrategy>().AsSelf();
            builder.RegisterType<ParallelogramStrategy>().AsSelf();
            builder.RegisterType<RhombusStrategy>().AsSelf();
            builder.RegisterType<DisplayResult>().As<IDisplayResult>();
            builder.RegisterType<DisplayCRUD>().As<IDisplayCRUD>();
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            builder.RegisterType<InputReaderRPS>().As<IInputReaderRPS>();
            builder.RegisterType<RPSService>().As<IRPSService>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<DisplayRPS>().As<IDisplayRPS>();
        }
    }
}
