using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<RectangleModel> RectangleModels { get; set; }
        DbSet<Triangle> Triangles { get; set; }
        DbSet<Parallelogram> Parallelograms { get; set; }
        DbSet<Calculator> Calculators { get; set; }
        DbSet<RockPaperScissor> RockPaperScissors { get; set; }


        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=TripleProject;Trusted_Connection=True;TrustServerCertificate=true;");
            } 
        }

    }

}
