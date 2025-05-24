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
    public class InputReader : IInputReader
    {
        public RectangleDTO GetRectangleInput()
        {
            AnsiConsole.MarkupLine("[bold yellow]Enter values for Rectangle:[/]");

            double width = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]base length[/]:")
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
                Base = (decimal)width,  
                Height = (decimal)height
            };
        }

        public ParallelogramDTO GetParallelogramInput()
        {
            AnsiConsole.MarkupLine("[bold yellow]Enter values for Parallelogram/Rhombus:[/]");
            double baseLength = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]base length[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(b => b > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Base length must be greater than 0[/]"))
            );
            double height = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]height[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(h => h > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Height must be greater than 0[/]"))
            );
            double side = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]side length[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(s => s > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Side length must be greater than 0[/]"))
            );
            return new ParallelogramDTO
            {
                Base = (decimal)baseLength,
                Height = (decimal)height,
                Side = (decimal)side
            };
        }

        public TriangleDTO GetTriangleInput()
        {
            AnsiConsole.MarkupLine("[bold yellow]Enter values for Triangle:[/]");
            double baseLength = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]base length[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(b => b > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Base length must be greater than 0[/]"))
            );
            double height = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]height[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(h => h > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Height must be greater than 0[/]"))
            );
            double sideA = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]side A length[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(a => a > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Side A length must be greater than 0[/]"))
            );
            double sideB = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]side B length[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(b => b > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Side B length must be greater than 0[/]"))
            );
            double sideC = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green]side C length[/]:")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid number[/]")
                    .Validate(c => c > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Side C length must be greater than 0[/]"))
            );
            return new TriangleDTO
            {
                Base = (decimal)baseLength,
                Height = (decimal)height,
                SideA = (decimal)sideA,
                SideB = (decimal)sideB,
                SideC = (decimal)sideC
            };
        }

    }
}
