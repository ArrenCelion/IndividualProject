using DataAccessLayer.Models;
using Services.Shapes.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.UI
{
    public class DisplayResult : IDisplayResult

    {
        public void DisplayRectangle(string shapeName, RectangleModel model)
        {
            var table = new Table();

            table.Border = TableBorder.Rounded;
            table.AddColumn("[yellow]Property[/]");
            table.AddColumn("[yellow]Value[/]");

            table.AddRow("Shape", shapeName);
            table.AddRow("Base", model.Base.ToString("N2"));
            table.AddRow("Height", model.Height.ToString("N2"));
            table.AddRow("Area", model.Area.ToString("N2"));
            table.AddRow("Circumference", model.Circumference.ToString("N2"));
            table.AddRow("Date of Calculation", model.DateOfCalculation.ToString("yyyy-MM-dd"));

            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine("[green]Calculation completed successfully and shape saved![/]");
            AnsiConsole.MarkupLine("[green]Press any key to go back to the menu...[/]");
            Console.ReadKey(true);

        }
    }
}
