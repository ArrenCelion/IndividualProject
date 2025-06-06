using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataInitializer
    {
        ApplicationDbContext _dbContext;
        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            _dbContext.Database.Migrate();
            SeedShapes();
            SeedCalculations();
            _dbContext.SaveChanges();
        }

        private void SeedShapes()
        {
            if (!_dbContext.ShapesModels.Any())
            {
                var shapes = new List<ShapesModel>
                {
                    new ShapesModel { ShapeName = "Rectangle", Base = 5, Height = 10, Area = 50, Circumference = 30, DateOfCalculation = DateOnly.FromDateTime(DateTime.Now) },
                    new ShapesModel { ShapeName = "Triangle", Base = 12, Height = 5, SideA = 5, SideB = 12, SideC = 13, Area = 30, Circumference = 30, DateOfCalculation = DateOnly.FromDateTime(DateTime.Now) },
                    new ShapesModel { ShapeName = "Parallelogram", Base = 6, Height = 7, SideA = 8, Area = 42, Circumference = 28, DateOfCalculation = DateOnly.FromDateTime(DateTime.Now) },
                    new ShapesModel { ShapeName = "Rhombus", Base = 5, Height = 5, SideA = 5, Area = 25, Circumference = 20, DateOfCalculation = DateOnly.FromDateTime(DateTime.Now) },
                };
                _dbContext.ShapesModels.AddRange(shapes);
                _dbContext.SaveChanges();
            }
        }
        private void SeedCalculations()
        {
            if (!_dbContext.CalculatorModels.Any())
            {
                var calculations = new List<CalculatorModel>
                {
                    new CalculatorModel { Operator = "+", Number1 = 5, Number2 = 10, Result = 15, DateOfCalculation = DateTime.Now },
                    new CalculatorModel { Operator = "-", Number1 = 20, Number2 = 8, Result = 12, DateOfCalculation = DateTime.Now },
                    new CalculatorModel { Operator = "*", Number1 = 3, Number2 = 7, Result = 21, DateOfCalculation = DateTime.Now },
                    new CalculatorModel { Operator = "/", Number1 = 15, Number2 = 3, Result = 5, DateOfCalculation = DateTime.Now },
                    new CalculatorModel { Operator = "%", Number1 = 10, Number2 = 3, Result = 1, DateOfCalculation = DateTime.Now },
                    new CalculatorModel { Operator = "√", Number1 = 16, Number2 = null, Result = 4, DateOfCalculation = DateTime.Now }
                };
                _dbContext.CalculatorModels.AddRange(calculations);
                _dbContext.SaveChanges();
            }
        }
    }
}
