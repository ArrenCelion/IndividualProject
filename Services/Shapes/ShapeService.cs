using DataAccessLayer;
using DataAccessLayer.Models;
using Services.Shapes.Interfaces;
using Services.Shapes.Strategies;
using Services.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes
{
    public class ShapeService : IShapeService
    {
        private readonly IRectangleInputReader _rectangleInputReader;
        private readonly RectangleStrategy _rectangleStrategy;
        private readonly ApplicationDbContext _dbContext;

        public ShapeService(IRectangleInputReader rectangleInputReader, RectangleStrategy rectangleStrategy, ApplicationDbContext dbContext)
        {
            _rectangleInputReader = rectangleInputReader;
            _rectangleStrategy = rectangleStrategy;
            _dbContext = dbContext;
        }

        public IDisplayResult DisplayResult { get; set; }

        public void CalculateShape(string input)
        {
            switch (input)
            {
                case "Rectangle":
                    CalculateAndSaveRectangle();
                    break;
                // Add cases for other shapes as needed
                default:
                    throw new NotImplementedException($"Shape '{input}' is not implemented.");
            }
        }

        public void CalculateAndSaveRectangle()
        {
            var dto = _rectangleInputReader.GetInput();

            // Calculate area and circumference (perimeter)
            var area = (decimal)_rectangleStrategy.CalculateArea(dto);
            var circumference = (decimal)_rectangleStrategy.CalculatePerimeter(dto);

            // Build the model to save
            var rectangleModel = new RectangleModel
            {
                Base = dto.Base,
                Height = dto.Height,
                Area = area,
                Circumference = circumference,
                DateOfCalculation = DateOnly.FromDateTime(DateTime.Now)
            };

            // Save to DB
            SaveRectangle(rectangleModel);

            // DisplayResult results
            DisplayResult.DisplayRectangle("Rectangle", rectangleModel);
        }

        public void SaveRectangle(RectangleModel rectangleModel)
        {
            _dbContext.RectangleModels.Add(rectangleModel);
            _dbContext.SaveChanges();
        }
    }
}
