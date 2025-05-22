using Autofac;
using Common.Interfaces;
using Common.Utilities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Modules
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DisplayMenu>().As<IDisplayMenu>().SingleInstance();

            builder.RegisterType<MenuService>().As<IMenuService>().SingleInstance();

        }
    }
}
