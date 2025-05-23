using DataAccessLayer.DTOs;
using Services.Shapes.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.UI
{
    public class RectangleInputReader : IRectangleInputReader
    {
        public RectangleDTO GetInput()
        {
            AnsiConsole.MarkupLine("[bold yellow]Enter values for Rectangle:[/]");

            double width = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]width[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(w => w > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Width must be greater than 0[/]"))
            );

            double height = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]height[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(h => h > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Height must be greater than 0[/]"))
            );

            return new RectangleDTO
            {
                Base = (decimal)width,   // assuming Base maps to Width
                Height = (decimal)height
            };
        }
    }
}
