using DataAccessLayer.Models;
using Services.Calculator.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.UI
{
    public class CalcDisplayCRUD : ICalcDisplayCRUD
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

        public void DisplayReadCalculations(List<CalculatorModel> calcList)
        {
            const int pageSize = 10;
            var sortedList = calcList
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
                        .Title("Select a [magenta2]page of calculations[/]:")
                        .PageSize(10)
                        .HighlightStyle(highlightStyle)
                        .AddChoices(pageOptions)
                );

                if (selectedPage == "Exit")
                    break;

                int currentPage = int.Parse(selectedPage.Split(' ')[1]);
                var calcsToShow = sortedList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var table = new Table()
                    .Title($"[magenta2]Shapes - Page {currentPage} of {totalPages}[/]")
                    .Border(TableBorder.Rounded);

                // Add columns for each property you want to display
                table.AddColumn("[violet]ID[/]");
                table.AddColumn("[violet]Operator[/]");
                table.AddColumn("[violet]First Number[/]");
                table.AddColumn("[violet]Second Number[/]");
                table.AddColumn("[violet]Result[/]");
                table.AddColumn("[violet]Date[/]");

                foreach (var c in calcsToShow)
                {
                    table.AddRow(
                        c.CalculatorModelId.ToString(),
                        c.Operator,
                        c.Number1.ToString(),
                        c.Number2?.ToString() ?? "-",
                        c.Result.ToString(),
                        c.DateOfCalculation.ToString()
                    );
                }

                AnsiConsole.Clear();
                AnsiConsole.Write(table);
            }
        }
    }
}
