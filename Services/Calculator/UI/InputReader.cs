using Services.Calculator.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.UI
{
    public class InputReader : IInputReader
    {
        public (string Operator, decimal Number1, decimal? Number2) GetCalculationInput(IEnumerable<string> availableOperators)
        {
            var operatorChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose an [green]operator[/]:")
                    .AddChoices(availableOperators)
            );

            decimal number1 = AnsiConsole.Prompt(
                new TextPrompt<decimal>("Enter the [green]first number[/]:")
            );

            // Adjust this logic for your unary operators
            bool isUnary = operatorChoice == "sqrt";

            decimal? number2 = null;
            if (!isUnary)
            {
                number2 = AnsiConsole.Prompt(
                    new TextPrompt<decimal>("Enter the [green]second number[/]:")
                );
            }

            return (operatorChoice, number1, number2);
        }
    }
}
