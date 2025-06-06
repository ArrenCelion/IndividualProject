using DataAccessLayer.DTOs;
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

        public CalculatorModel DisplaySelectCalculation(List<CalculatorModel> calcList)
        {
            if (calcList == null || !calcList.Any())
            {
                AnsiConsole.MarkupLine("[red]No calculations available to select.[/]");
                return null;
            }
            var selectedCalc = AnsiConsole.Prompt(
                new SelectionPrompt<CalculatorModel>()
                    .Title("Select a [magenta2]calculation[/]:")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use arrow keys to navigate)[/]")
                    .HighlightStyle(new Style().Foreground(Color.Fuchsia))
                    .AddChoices(calcList)
                    .UseConverter(calc =>
                        $"ID: {calc.CalculatorModelId} | {calc.Number1} {calc.Operator} {calc.Number2?.ToString() ?? ""} = {calc.Result} | Date: {calc.DateOfCalculation.ToString("yyyy-MM-dd HH:mm:ss")}"
                    )
            );
            return selectedCalc;
        }

        public CalculatorUpdateInput GetUpdatedCalculatorInput(CalculatorModel calc)
        {
            var input = new CalculatorUpdateInput();

            var operators = new[] { "+", "-", "*", "/", "%", "√" };
            var opPrompt = new SelectionPrompt<string>()
                .Title($"Select new [green]Operator[/] (current: {calc.Operator}, select 'Keep current' to leave unchanged):")
                .AddChoices(operators.Append("Keep current").ToArray());

            var selectedOp = AnsiConsole.Prompt(opPrompt);
            input.Operator = selectedOp == "Keep current" ? null : selectedOp;

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

            var number1Input = Prompt("First Number", calc.Number1);
            input.Number1 = number1Input ?? calc.Number1;

            var opToCheck = input.Operator ?? calc.Operator;
            if (opToCheck != "√")
            {
                decimal? number2Input = null;
                do
                {
                    number2Input = Prompt("Second Number", calc.Number2);
                    if (!number2Input.HasValue && !calc.Number2.HasValue)
                    {
                        AnsiConsole.MarkupLine("[red]Second Number is required for this operation. Please enter a value.[/]");
                    }
                }
                while (!number2Input.HasValue && !calc.Number2.HasValue);

                input.Number2 = number2Input ?? calc.Number2;
            }
            else
            {
                input.Number2 = null;
            }

            return input;
        }

        public void DisplayCalculator(CalculatorModel model)
        {
            var table = new Table()
                .Border(TableBorder.Rounded)
                .Title($"[yellow]Calculation Details - ID {model.CalculatorModelId}[/]");
            table.AddColumn("[yellow]Property[/]");
            table.AddColumn("[yellow]Value[/]");
            table.AddRow("ID", model.CalculatorModelId.ToString());
            table.AddRow("Operator", model.Operator);
            table.AddRow("First Number", model.Number1.ToString("N2"));
            table.AddRow("Second Number", model.Number2?.ToString("N2") ?? "-");
            table.AddRow("Result", model.Result.ToString("N2"));
            table.AddRow("Date of Calculation", model.DateOfCalculation.ToString("yyyy-MM-dd HH:mm:ss"));
            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine("[green]Calculation details updated successfully![/]");
            AnsiConsole.MarkupLine("[green]Press any key to go back to the menu...[/]");
            Console.ReadKey(true);
        }
    }
}
