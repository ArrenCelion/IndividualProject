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
        private readonly IInputReader _inputReader;
        private readonly RectangleStrategy _rectangleStrategy;
        private readonly TriangleStrategy _triangleStrategy;
        private readonly ParallelogramStrategy _parallelogramStrategy; // Assuming you have a strategy for parallelogram
        private readonly ApplicationDbContext _dbContext;

        public ShapeService(IInputReader inputReader, RectangleStrategy rectangleStrategy, ApplicationDbContext dbContext, TriangleStrategy triangleStrategy, ParallelogramStrategy parallelogramStrategy)
        {
            _inputReader = inputReader;
            _rectangleStrategy = rectangleStrategy;
            _dbContext = dbContext;
            _triangleStrategy = triangleStrategy;
            _parallelogramStrategy = parallelogramStrategy;
        }

        public IDisplayResult DisplayResult { get; set; }

        public void CalculateShape(string input)
        {
            switch (input)
            {
                case "Rectangle":
                    CalculateRectangle();
                    break;
                case "Parallelogram":
                case "Rhombus":
                    CalculateParallelogram();
                    break;
                case "Triangle":
                    CalculateTriangle();
                    break;
                default:
                    throw new NotImplementedException($"Shape '{input}' is not implemented.");
            }
        }

        public void CalculateRectangle()
        {
            var dto = _inputReader.GetRectangleInput();

            var area = (decimal)_rectangleStrategy.CalculateArea(dto);
            var circumference = (decimal)_rectangleStrategy.CalculateCircumference(dto);

            var rectangleModel = new RectangleModel
            {
                Base = dto.Base,
                Height = dto.Height,
                Area = area,
                Circumference = circumference,
                DateOfCalculation = DateOnly.FromDateTime(DateTime.Now)
            };

            SaveRectangle(rectangleModel);

            DisplayResult.DisplayRectangle("Rectangle", rectangleModel);
        }

        public void CalculateTriangle()
        {
            var dto = _inputReader.GetTriangleInput();
            var area = (decimal)_triangleStrategy.CalculateArea(dto);
            var circumference = (decimal)_triangleStrategy.CalculateCircumference(dto);

            var triangleModel = new Triangle
            {
                Base = dto.Base,
                Height = dto.Height,
                SideA = dto.SideA,
                SideB = dto.SideB,
                SideC = dto.SideC,
                Area = area,
                Circumference = circumference,
                DateOfCalculation = DateOnly.FromDateTime(DateTime.Now)
            };

            SaveTriangle(triangleModel);

            DisplayResult.DisplayTriangle("Triangle", triangleModel);
        }

        public void CalculateParallelogram()
        {
            var dto = _inputReader.GetParallelogramInput();
            var area = (decimal)_parallelogramStrategy.CalculateArea(dto);
            var circumference = (decimal)_parallelogramStrategy.CalculateCircumference(dto);
            bool isRhombus = dto.Base == dto.Side;

            var parallelogramModel = new Parallelogram
            {
                Base = dto.Base,
                Height = dto.Height,
                Side = dto.Side,
                Area = area,
                Circumference = circumference,
                DateOfCalculation = DateOnly.FromDateTime(DateTime.Now),
                IsRhombus = isRhombus
            };

            SaveParallelogram(parallelogramModel);
            if (isRhombus)
            {
                DisplayResult.DisplayParallelogram("Rhombus", parallelogramModel);
            }
            else
                DisplayResult.DisplayParallelogram("Parallelogram", parallelogramModel);
        }

        public void SaveRectangle(RectangleModel rectangleModel)
        {
            _dbContext.RectangleModels.Add(rectangleModel);
            _dbContext.SaveChanges();
        }

        public void SaveTriangle(Triangle triangleModel)
        {
            _dbContext.Triangles.Add(triangleModel);
            _dbContext.SaveChanges();
        }

        public void SaveParallelogram(Parallelogram parallelogramModel)
        {
            _dbContext.Parallelograms.Add(parallelogramModel);
            _dbContext.SaveChanges();
        }
    }
}
