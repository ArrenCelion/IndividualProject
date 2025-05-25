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
        private readonly IDisplayCRUD _displayCRUD;

        public ShapeService(IInputReader inputReader, RectangleStrategy rectangleStrategy, ApplicationDbContext dbContext, TriangleStrategy triangleStrategy, ParallelogramStrategy parallelogramStrategy, IDisplayCRUD displayCRUD)
        {
            _inputReader = inputReader;
            _rectangleStrategy = rectangleStrategy;
            _dbContext = dbContext;
            _triangleStrategy = triangleStrategy;
            _parallelogramStrategy = parallelogramStrategy;
            _displayCRUD = displayCRUD;
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

            var rectangleModel = new ShapesModel
            {
                ShapeName = "Rectangle",
                Base = dto.Base,
                Height = dto.Height,
                Area = area,
                Circumference = circumference,
                DateOfCalculation = DateOnly.FromDateTime(DateTime.Now)
            };

            SaveShape(rectangleModel);

            DisplayResult.DisplayShape(rectangleModel);
        }

        public void CalculateTriangle()
        {
            var dto = _inputReader.GetTriangleInput();
            var area = (decimal)_triangleStrategy.CalculateArea(dto);
            var circumference = (decimal)_triangleStrategy.CalculateCircumference(dto);

            var triangleModel = new ShapesModel
            {
                ShapeName = "Triangle",
                Base = dto.Base,
                Height = dto.Height,
                SideA = dto.SideA,
                SideB = dto.SideB,
                SideC = dto.SideC,
                Area = area,
                Circumference = circumference,
                DateOfCalculation = DateOnly.FromDateTime(DateTime.Now)
            };

            SaveShape(triangleModel);

            DisplayResult.DisplayShape(triangleModel);
        }


        public void CalculateParallelogram()
        {
            var dto = _inputReader.GetParallelogramInput();
            var area = (decimal)_parallelogramStrategy.CalculateArea(dto);
            var circumference = (decimal)_parallelogramStrategy.CalculateCircumference(dto);
            bool isRhombus = dto.Base == dto.SideA;


            var parallelogramModel = new ShapesModel
            {
                Base = dto.Base,
                Height = dto.Height,
                SideA = dto.SideA,
                Area = area,
                Circumference = circumference,
                DateOfCalculation = DateOnly.FromDateTime(DateTime.Now),
            };

            if (isRhombus)
            {
                parallelogramModel.ShapeName = "Rhombus";
            }
            else
            {
                parallelogramModel.ShapeName = "Parallelogram";
            }
      
            SaveShape(parallelogramModel);

            DisplayResult.DisplayShape(parallelogramModel);
        }

        public void SaveShape (ShapesModel shapesModel)
        {
            _dbContext.ShapesModels.Add(shapesModel);
            _dbContext.SaveChanges();
        }

        /* READ */
        public void ReadWhatShapes(string shape)
        {
            switch (shape)
            {
                case "Rectangle":
                case "Triangle":
                case "Parallelogram":
                case "Rhombus":
                    ReadAllSpecificShape(shape);
                    break;
                case "All Shapes":
                    ReadAllShapes();
                    break;
                default:
                    throw new NotImplementedException($"Shape '{shape}' is not implemented for display.");
            }
        }
        public void ReadAllShapes()
        {

           var allShapes = _dbContext.ShapesModels.ToList();

           _displayCRUD.DisplayReadShapes(allShapes);
        }

        public void ReadAllSpecificShape(string shape)
        {

            var allSpecificShape = _dbContext.ShapesModels.Where(s => s.ShapeName == shape).ToList();
            if (allSpecificShape.Count == 0)
            {
                throw new InvalidOperationException($"No {shape} found.");
            }
            _displayCRUD.DisplayReadShapes(allSpecificShape);
        }

        /* UPDATE */

        //public void UpdateShape(string shape)
        //{
        //    var shapeId = SelectOneShape(shape);
        //    _displayCRUD.DisplayUpdateShape(shapeId, shape);

        //}

        //public int SelectOneShape(string shape)
        //{
        //    List<object> shapeList = null; // Initialize the variable with a default value
        //    var selectedShape = new object(); // Initialize to avoid null reference
        //    int shapeId = 0; // Initialize to avoid null reference
        //    switch (shape)
        //    {
        //        case "Rectangle":
        //            shapeList = _dbContext.RectangleModels.ToList<object>();
        //            selectedShape = _displayCRUD.DisplaySelectShape(shapeList);
        //            shapeId = ((RectangleModel)selectedShape).RectangleModelId;
        //            break;
        //        case "Triangle":
        //            shapeList = _dbContext.Triangles.ToList<object>();
        //            selectedShape = _displayCRUD.DisplaySelectShape(shapeList);
        //            shapeId = ((Triangle)selectedShape).TriangleId;
        //            break;
        //        case "Parallelogram":
        //            shapeList = _dbContext.Parallelograms.Where(p => !p.IsRhombus).ToList<object>();
        //            selectedShape = _displayCRUD.DisplaySelectShape(shapeList);
        //            shapeId = ((Parallelogram)selectedShape).ParallelogramId;
        //            break;
        //        case "Rhombus":
        //            shapeList = _dbContext.Parallelograms.Where(p => p.IsRhombus).ToList<object>();
        //            selectedShape = _displayCRUD.DisplaySelectShape(shapeList);
        //            shapeId = ((Parallelogram)selectedShape).ParallelogramId;
        //            break;
        //        default:
        //            break;
        //    }

        //    if (selectedShape == null || shapeId == 0)
        //    {
        //        throw new InvalidOperationException($"No {shape} found to update.");
        //    }

        //    return shapeId;
        //}
    }
}
