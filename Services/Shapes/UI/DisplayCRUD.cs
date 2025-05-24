using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Services.Shapes;
using Services.Shapes.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.UI
{
    public class DisplayCRUD : IDisplayCRUD
    {
        private readonly IShapeService _shapeService;


        public DisplayCRUD(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        public void DisplayReadShapes(string shape)
        {
            var shapeList = new List<string>();
            switch (shape)
            {
                case "Rectangle":
                    shapeList = _shapeService.ReadAllRectangles();
                    break;
                case "Triangle":
                    shapeList = _shapeService.ReadAllTriangles();
                    break;
                case "Parallelogram":
                case "Rhombus":
                    shapeList = _shapeService.ReadAllParallelograms(shape.ToLower());
                    break;
                case "All Shapes":
                    shapeList = _shapeService.ReadAllShapes();
                    break;
                default:
                    throw new NotImplementedException($"Shape '{shape}' is not implemented for display.");
            }

            const int pageSize = 10;
            int totalPages = (int)Math.Ceiling(shapeList.Count / (double)pageSize);

            while (true)
            {
                var highlightStyle = new Style().Foreground(Color.Fuchsia);

                var pageOptions = Enumerable.Range(1, totalPages)
                    .Select(i => $"Page {i}")
                    .Append("Exit")
                    .ToList();

                var selectedPage = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select a [magenta2]page of shapes[/]:")
                        .PageSize(10)
                        .HighlightStyle(highlightStyle)
                        .AddChoices(pageOptions)
                );

                if (selectedPage == "Exit")
                    break;

                int currentPage = int.Parse(selectedPage.Split(' ')[1]);
                var shapesToShow = shapeList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var table = new Table()
                    .Title($"[magenta2]Shapes - Page {currentPage} of {totalPages}[/]")
                    .Border(TableBorder.Rounded);
                table.AddColumn("[violet]Shape Info[/]");

                foreach (var s in shapesToShow)
                {
                    table.AddRow(s);
                }

                AnsiConsole.Clear();
                AnsiConsole.Write(table);

            }
        }
    }
}
