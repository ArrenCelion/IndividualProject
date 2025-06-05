using Services.Calculator.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.UI
{
    public class DisplayCRUD : IDisplayCRUD
    {
        public bool DisplayCalculationResult(string operation, decimal number1, decimal? number2, decimal result)
        {
            if (number2.HasValue)
                AnsiConsole.MarkupLine($"[yellow]Calculation:[/] {number1} {operation} {number2} = {result}");
            else
                AnsiConsole.MarkupLine($"[yellow]Calculation:[/] {operation}({number1}) = {result}");

            var anotherCalculation = AnsiConsole.Prompt(
                new TextPrompt<string>("Would you like to make another calculation? (y/n)")
                    .AllowEmpty()
                    .Validate(input => input.ToLower() == "y" || input.ToLower() == "n"
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[red]Invalid input, please enter 'y' or 'n'.[/]"))
            );
            if (anotherCalculation.ToLower() == "y")
                return true;

            AnsiConsole.MarkupLine("[green]Press any key to go back to the menu...[/]");
            Console.ReadKey(true);
            return false;

        }
    }
}
