﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccessLayer.Models.CalculatorModel", b =>
                {
                    b.Property<int>("CalculatorModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalculatorModelId"));

                    b.Property<DateTime>("DateOfCalculation")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Number1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Number2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Operator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Result")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CalculatorModelId");

                    b.ToTable("CalculatorModels", (string)null);
                });

            modelBuilder.Entity("DataAccessLayer.Models.RockPaperScissor", b =>
                {
                    b.Property<int>("RockPaperScissorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RockPaperScissorId"));

                    b.Property<string>("ComputerHand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfGame")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GamesWonAverage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PlayerHand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RockPaperScissorId");

                    b.ToTable("RockPaperScissors", (string)null);
                });

            modelBuilder.Entity("DataAccessLayer.Models.ShapesModel", b =>
                {
                    b.Property<int>("ShapesModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShapesModelId"));

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Base")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Circumference")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("DateOfCalculation")
                        .HasColumnType("date");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShapeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SideA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SideB")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SideC")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ShapesModelId");

                    b.ToTable("ShapesModels", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
