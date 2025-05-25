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
        private readonly ApplicationDbContext _dbContext;


        public DisplayCRUD(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DisplayReadShapes(List<ShapesModel> shapeList)
        {
            const int pageSize = 10;
            // Sort by DateOfCalculation descending (newest first)
            var sortedList = shapeList
                .OrderByDescending(s => s.DateOfCalculation)
                .ToList();

            int totalPages = (int)Math.Ceiling(sortedList.Count / (double)pageSize);

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
                var shapesToShow = sortedList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var table = new Table()
                    .Title($"[magenta2]Shapes - Page {currentPage} of {totalPages}[/]")
                    .Border(TableBorder.Rounded);

                // Add columns for each property you want to display
                table.AddColumn("[violet]ID[/]");
                table.AddColumn("[violet]Shape Name[/]");
                table.AddColumn("[violet]Base[/]");
                table.AddColumn("[violet]Height[/]");
                table.AddColumn("[violet]SideA[/]");
                table.AddColumn("[violet]SideB[/]");
                table.AddColumn("[violet]SideC[/]");
                table.AddColumn("[violet]Area[/]");
                table.AddColumn("[violet]Circumference[/]");
                table.AddColumn("[violet]Date[/]");

                foreach (var s in shapesToShow)
                {
                    table.AddRow(
                        s.ShapesModelId.ToString(),
                        s.ShapeName,
                        s.Base.ToString(),
                        s.Height.ToString(),
                        s.SideA?.ToString() ?? "-",
                        s.SideB?.ToString() ?? "-",
                        s.SideC?.ToString() ?? "-",
                        s.Area.ToString(),
                        s.Circumference.ToString(),
                        s.DateOfCalculation.ToString()
                    );
                }

                AnsiConsole.Clear();
                AnsiConsole.Write(table);
            }
        }

        public object DisplaySelectShape(List<object> shapeList)
        {
            var selectedShape = AnsiConsole.Prompt(
                new SelectionPrompt<object>()
                    .Title("Select a [magenta2]shape[/]:")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use arrow keys to navigate)[/]")
                    .HighlightStyle(new Style().Foreground(Color.Fuchsia))
                    .AddChoices(shapeList)
            );
            return selectedShape;
        }

        public void DisplayUpdateShape(int shapeId, string shape)
        {
            
        }
    }
}
   