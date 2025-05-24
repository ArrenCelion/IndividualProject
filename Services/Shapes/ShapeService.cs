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
    //TODO: Add CalculationService to handle calculations separately
    public class ShapeService : IShapeService
    {
        private readonly IInputReader _inputReader;
        private readonly RectangleStrategy _rectangleStrategy;
        private readonly TriangleStrategy _triangleStrategy;
        private readonly ParallelogramStrategy _parallelogramStrategy;
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

        /* READ */

        public List<string> ReadAllShapes()
        {

            var rectangles = ReadAllRectangles();
            var triangles = ReadAllTriangles();
            var parallelograms = ReadAllParallelograms("parallelograms");
            var rhombuses = ReadAllParallelograms("rhombus");

            var allShapes = new List<string>();
            allShapes.AddRange(rectangles);
            allShapes.AddRange(triangles);
            allShapes.AddRange(parallelograms);
            allShapes.AddRange(rhombuses);

            return allShapes;
        }

        public List<string> ReadAllRectangles()
        {
            var rectangles = _dbContext.RectangleModels
                  .Select(r => new
                  {
                      Shape = "Rectangle",
                      Base = r.Base.ToString(),
                      Height = r.Height.ToString(),
                      Area = r.Area.ToString(),
                      Circumference = r.Circumference.ToString(),
                      Date = r.DateOfCalculation.ToString()
                  });

            return rectangles.Select(r =>
                $"{r.Shape}, Base: {r.Base}, Height: {r.Height}, Area: {r.Area}, Circumference: {r.Circumference}, Date: {r.Date}"
            ).ToList();
        }
        public List<string> ReadAllTriangles()
        {
            var triangles = _dbContext.Triangles
                  .Select(t => new
                  {
                      Shape = "Triangle",
                      Base = t.Base.ToString(),
                      Height = t.Height.ToString(),
                      Area = t.Area.ToString(),
                      Circumference = t.Circumference.ToString(),
                      Date = t.DateOfCalculation.ToString()
                  });

            return triangles.Select(t =>
                $"{t.Shape}, Base: {t.Base}, Height: {t.Height}, Area: {t.Area}, Circumference: {t.Circumference}, Date: {t.Date}"
            ).ToList();
        }
        public List<string> ReadAllParallelograms(string type)
        {
            if (type == "rhombus")
            {
                var rhombuses = _dbContext.Parallelograms
                    .Where(p => p.IsRhombus)
                    .Select(p => new
                    {
                        Shape = "Rhombus",
                        Base = p.Base.ToString(),
                        Height = p.Height.ToString(),
                        Area = p.Area.ToString(),
                        Circumference = p.Circumference.ToString(),
                        Date = p.DateOfCalculation.ToString()
                    });

                return rhombuses.Select(r =>
                    $"{r.Shape}, Base: {r.Base}, Height: {r.Height}, Area: {r.Area}, Circumference: {r.Circumference}, Date: {r.Date}"
                ).ToList();
            }
            else
            {
                var parallelograms = _dbContext.Parallelograms
                    .Where(p => !p.IsRhombus)
                    .Select(p => new
                    {
                        Shape = "Parallelogram",
                        Base = p.Base.ToString(),
                        Height = p.Height.ToString(),
                        Area = p.Area.ToString(),
                        Circumference = p.Circumference.ToString(),
                        Date = p.DateOfCalculation.ToString()
                    });

                return parallelograms.Select(p =>
                    $"{p.Shape}, Base: {p.Base}, Height: {p.Height}, Area: {p.Area}, Circumference: {p.Circumference}, Date: {p.Date}"
                ).ToList();
            }
        }

    }
}
