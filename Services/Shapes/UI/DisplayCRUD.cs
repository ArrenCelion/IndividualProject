using DataAccessLayer;
using DataAccessLayer.DTOs;
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

        public ShapesModel DisplaySelectShape(List<ShapesModel> shapeList)
        {
            if (shapeList == null || !shapeList.Any())
            {
                AnsiConsole.MarkupLine("[red]No shapes available to select.[/]");
                return null;
            }
            var selectedShape = AnsiConsole.Prompt(
                new SelectionPrompt<ShapesModel>()
                    .Title("Select a [magenta2]shape[/]:")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use arrow keys to navigate)[/]")
                    .HighlightStyle(new Style().Foreground(Color.Fuchsia))
                    .AddChoices(shapeList)
                    .UseConverter(shape => $"{shape.ShapeName} (ID: {shape.ShapesModelId}) - Area: {shape.Area}, Circumference: {shape.Circumference}, Date: {shape.DateOfCalculation.ToShortDateString()}")
            );
            return selectedShape;
        }

        public ShapeUpdateInput GetUpdatedShapeInput(ShapesModel shape)
        {
            var input = new ShapeUpdateInput();

            decimal? Prompt(string prop, decimal? current)
            {
                var prompt = new TextPrompt<string>($"Enter new value for [green]{prop}[/] (current: {current?.ToString() ?? "null"}, leave blank to keep):")
                    .AllowEmpty();
                var val = AnsiConsole.Prompt(prompt);
                if (string.IsNullOrWhiteSpace(val)) return null;
                if (decimal.TryParse(val, out var result)) return result;
                AnsiConsole.MarkupLine("[red]Invalid input. Value not updated.[/]");
                return null;
            }

            input.Base = Prompt("Base", shape.Base);
            input.Height = Prompt("Height", shape.Height);
            if (shape.SideA.HasValue) input.SideA = Prompt("SideA", shape.SideA);
            if (shape.SideB.HasValue) input.SideB = Prompt("SideB", shape.SideB);
            if (shape.SideC.HasValue) input.SideC = Prompt("SideC", shape.SideC);

            return input;
        }

        public void DisplayShape(ShapesModel model)
        {
            var table = new Table()
                .Border(TableBorder.Rounded)
                .Title($"[yellow]Shape Details - {model.ShapeName}[/]");
            table.AddColumn("[yellow]Property[/]");
            table.AddColumn("[yellow]Value[/]");
            table.AddRow("ID", model.ShapesModelId.ToString());
            table.AddRow("Base", model.Base.ToString("N2"));
            table.AddRow("Height", model.Height.ToString("N2"));
            if (model.SideA.HasValue) table.AddRow("Side A", model.SideA.Value.ToString("N2"));
            if (model.SideB.HasValue) table.AddRow("Side B", model.SideB.Value.ToString("N2"));
            if (model.SideC.HasValue) table.AddRow("Side C", model.SideC.Value.ToString("N2"));
            table.AddRow("Area", model.Area.ToString("N2"));
            table.AddRow("Circumference", model.Circumference.ToString("N2"));
            table.AddRow("Date of Calculation", model.DateOfCalculation.ToString("yyyy-MM-dd"));
            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine("[green]Shape details updated successfully![/]");
            AnsiConsole.MarkupLine("[green]Press any key to go back to the menu...[/]");
        }
    }
}
   