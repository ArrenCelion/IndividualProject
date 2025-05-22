using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Modules
{
    public class DataAccessModule : Module
    {
        private readonly IConfiguration _config;

        public DataAccessModule(IConfiguration config)
        {
            _config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));

                return new ApplicationDbContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();
        }
    }
}
