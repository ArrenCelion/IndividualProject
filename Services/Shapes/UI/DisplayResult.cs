using DataAccessLayer.Models;
using Services.Shapes.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.UI
{
    public class DisplayResult : IDisplayResult

    {
        public void DisplayShape(ShapesModel model)
        {
            var table = new Table();

            table.Border = TableBorder.Rounded;
            table.AddColumn("[yellow]Property[/]");
            table.AddColumn("[yellow]Value[/]");

            table.AddRow("Shape", model.ShapeName);
            table.AddRow("ID", model.ShapesModelId.ToString());
            table.AddRow("Base", model.Base.ToString("N2"));
            table.AddRow("Height", model.Height.ToString("N2"));
            if(model.SideA != null)
            {
                table.AddRow("Side A", model.SideA.Value.ToString("N2"));
            }
            if (model.SideB != null)
            {
                table.AddRow("Side B", model.SideB.Value.ToString("N2"));
            }
            if (model.SideC != null)
            {
                table.AddRow("Side C", model.SideC.Value.ToString("N2"));
            }
            table.AddRow("Area", model.Area.ToString("N2"));
            table.AddRow("Circumference", model.Circumference.ToString("N2"));
            table.AddRow("Date of Calculation", model.DateOfCalculation.ToString("yyyy-MM-dd"));

            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine("[green]Calculation completed successfully and " + model.ShapeName + " saved![/]");
        }
    }
}
