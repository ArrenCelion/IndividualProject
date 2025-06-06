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
        public DbSet<ShapesModel> ShapesModels { get; set; }
        public DbSet<CalculatorModel> CalculatorModels { get; set; }
        public DbSet<RockPaperScissor> RockPaperScissors { get; set; }


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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalculatorModel>(entity =>
            {
                entity.Property(e => e.Number1).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Number2).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Result).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ShapesModel>(entity =>
            {
                entity.Property(e => e.Base).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Height).HasColumnType("decimal(18,2)");
                entity.Property(e => e.SideA).HasColumnType("decimal(18,2)");
                entity.Property(e => e.SideB).HasColumnType("decimal(18,2)");
                entity.Property(e => e.SideC).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Area).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Circumference).HasColumnType("decimal(18,2)");
            });
        }
    }

}
