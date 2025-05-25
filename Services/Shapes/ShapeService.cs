using DataAccessLayer;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Services.Modules;
using Services.Shapes.Interfaces;
using Services.Shapes.Strategies;
using Spectre.Console;
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
                    CalculateParallelogram(input);
                    break;
                case "Rhombus":
                    CalculateParallelogram(input);
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

            SaveShape(rectangleModel, false);

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

            SaveShape(triangleModel, false);

            DisplayResult.DisplayShape(triangleModel);
        }


        public void CalculateParallelogram(string shape)
        {
            var dto = _inputReader.GetParallelogramInput(shape);
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
      
            SaveShape(parallelogramModel, false);

            DisplayResult.DisplayShape(parallelogramModel);
        }

        public void SaveShape(ShapesModel shapesModel, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.ShapesModels.Update(shapesModel);
            }
            else
            {
                _dbContext.ShapesModels.Add(shapesModel);
            }
            _dbContext.SaveChanges();
        }

        /* READ */
        public void ReadWhatShapes(string shape)
        {
            var shapesToDisplay = new List<ShapesModel>();
            switch (shape)
            {
                case "Rectangle":
                case "Triangle":
                case "Parallelogram":
                case "Rhombus":
                    shapesToDisplay = ReadAllSpecificShape(shape);
                    break;
                case "All Shapes":
                    shapesToDisplay = ReadAllShapes();
                    break;
                default:
                    throw new NotImplementedException($"Shape '{shape}' is not implemented for display.");
            }

            _displayCRUD.DisplayReadShapes(shapesToDisplay);
        }
        public List<ShapesModel> ReadAllShapes()
        {

           var allShapes = _dbContext.ShapesModels.ToList();
           return allShapes;
        }

        public List<ShapesModel> ReadAllSpecificShape(string shape)
        {

            var allSpecificShape = _dbContext.ShapesModels.Where(s => s.ShapeName == shape).ToList();
            if (allSpecificShape.Count == 0)
            {
                AnsiConsole.MarkupLine($"[red]No shapes of type '{shape}' found.[/]");
            }
            return allSpecificShape;
        }

        /* UPDATE */

        public void UpdateShape(string shape)
        {
            var selectedShape = SelectOneShape(shape);
            if (selectedShape == null)
            {
                AnsiConsole.MarkupLine("[red]Press any key to go back to the menu...[/]");
                Console.ReadKey(true);
                return;
            }
            var shapeToUpdate = _displayCRUD.GetUpdatedShapeInput(selectedShape);

            ApplyShapeUpdates(selectedShape, shapeToUpdate);
        }

        public void DeleteShape(string shape)
        {
            var selectedShape = SelectOneShape(shape);
            if (selectedShape == null)
            {
                AnsiConsole.MarkupLine("[red]Press any key to go back to the menu...[/]");
                Console.ReadKey(true);
                return;
            }
            AnsiConsole.MarkupLine($"[yellow]Are you sure you want to delete the shape '{selectedShape.ShapeName}' with ID {selectedShape.ShapesModelId}? (y/n)[/]");
            var confirmation = AnsiConsole.Prompt(new TextPrompt<string>("Press [green]y[/] to confirm or [red]n[/] to cancel:")
                .AllowEmpty().Validate(input => input.ToLower() == "y" || input.ToLower() == "n" ? ValidationResult.Success() : ValidationResult.Error("[red]Invalid input, please enter 'y' or 'n'.[/]")));
            
            if (confirmation.ToLower() != "y")
            {
                AnsiConsole.MarkupLine("[red]Shape deletion cancelled.[/]");
                AnsiConsole.MarkupLine("[green]Press any key to go back to the menu...[/]");
                Console.ReadKey(true);
                return;
            }
            else
            {
                _dbContext.ShapesModels.Remove(selectedShape);
                _dbContext.SaveChanges();
                AnsiConsole.MarkupLine($"[green]Shape '{selectedShape.ShapeName}' with ID {selectedShape.ShapesModelId} deleted successfully![/]");
                AnsiConsole.MarkupLine("[green]Press any key to go back to the menu...[/]");
                Console.ReadKey(true);
                return;
            }

        }
        public void ApplyShapeUpdates(ShapesModel shape, ShapeUpdateInput input)
        {
            bool recalc = false;

            if (input.Base.HasValue && input.Base.Value != shape.Base) { shape.Base = input.Base.Value; recalc = true; }
            if (input.Height.HasValue && input.Height.Value != shape.Height) { shape.Height = input.Height.Value; recalc = true; }
            if (input.SideA.HasValue && input.SideA.Value != shape.SideA) { shape.SideA = input.SideA; recalc = true; }
            if (input.SideB.HasValue && input.SideB.Value != shape.SideB) { shape.SideB = input.SideB; recalc = true; }
            if (input.SideC.HasValue && input.SideC.Value != shape.SideC) { shape.SideC = input.SideC; recalc = true; }

            if (recalc)
            {
                switch (shape.ShapeName)
                {
                    case "Rectangle":
                        var rectDto = new RectangleDTO
                        {
                            Base = shape.Base,
                            Height = shape.Height
                        };
                        shape.Area = (decimal)_rectangleStrategy.CalculateArea(rectDto);
                        shape.Circumference = (decimal)_rectangleStrategy.CalculateCircumference(rectDto);
                        break;

                    case "Triangle":
                        var triDto = new TriangleDTO
                        {
                            Base = shape.Base,
                            Height = shape.Height,
                            SideA = shape.SideA ?? 0,
                            SideB = shape.SideB ?? 0,
                            SideC = shape.SideC ?? 0
                        };
                        shape.Area = (decimal)_triangleStrategy.CalculateArea(triDto);
                        shape.Circumference = (decimal)_triangleStrategy.CalculateCircumference(triDto);
                        break;

                    case "Parallelogram":
                    case "Rhombus":
                        var paraDto = new ParallelogramDTO
                        {
                            Base = shape.Base,
                            Height = shape.Height,
                            SideA = shape.SideA ?? 0
                        };
                        shape.Area = (decimal)_parallelogramStrategy.CalculateArea(paraDto);
                        shape.Circumference = (decimal)_parallelogramStrategy.CalculateCircumference(paraDto);
                        break;
                }

                SaveShape(shape, true);
                _displayCRUD.DisplayShape(shape);
            }
        }

        public ShapesModel SelectOneShape(string shape)
        {
            var shapeList = ReadAllSpecificShape(shape).ToList();

            if (shapeList.Count == 0)
            {
                return null;
            }

            ShapesModel selectedShape = _displayCRUD.DisplaySelectShape(shapeList);
            return selectedShape;
        }
    }
}
