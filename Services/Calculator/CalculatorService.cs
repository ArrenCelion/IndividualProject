using Azure;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Services.Calculator.Interfaces;
using Services.Calculator.Strategies;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICalcInputReader _inputReader;
        private readonly ICalcDisplayCRUD _displayCRUD;

        // Declare instances of the strategies  
        private readonly AdditionStrategy _additionStrategy;
        private readonly SubtractionStrategy _subtractionStrategy;
        private readonly MultiplicationStrategy _multiplicationStrategy;
        private readonly DivisionStrategy _divisionStrategy;
        private readonly ModulusStrategy _modulusStrategy;
        private readonly SquareRootStrategy _squareRootStrategy;

        public CalculatorService(ICalcInputReader inputReader, ICalcDisplayCRUD displayCRUD, ApplicationDbContext dbContext, AdditionStrategy additionStrategy, SubtractionStrategy subtractionStrategy, MultiplicationStrategy multiplicationStrategy, DivisionStrategy divisionStrategy, ModulusStrategy modulusStrategy, SquareRootStrategy squareRootStrategy)
        {
            _dbContext = dbContext;
            _inputReader = inputReader;
            _displayCRUD = displayCRUD;

            _additionStrategy = additionStrategy;
            _subtractionStrategy = subtractionStrategy;
            _multiplicationStrategy = multiplicationStrategy;
            _divisionStrategy = divisionStrategy;
            _modulusStrategy = modulusStrategy;
            _squareRootStrategy = squareRootStrategy;
        }

        public void StartCalculation()
        {
            string[] availableOperators = { "+", "-", "*", "/", "%", "√" };
            var (operatorChoice, number1, number2) = _inputReader.GetCalculationInput(availableOperators);

            var result = operatorChoice switch
            {
                "+" => _additionStrategy.Execute(number1, number2),
                "-" => _subtractionStrategy.Execute(number1, number2),
                "*" => _multiplicationStrategy.Execute(number1, number2),
                "/" => _divisionStrategy.Execute(number1, number2),
                "%" => _modulusStrategy.Execute(number1, number2),
                "√" => _squareRootStrategy.Execute(number1, number2),
                _ => throw new InvalidOperationException("Invalid operator")
            };

            var calculation = new CalculatorModel
            {
                Operator = operatorChoice,
                Number1 = number1,
                Number2 = number2,
                Result = result,
                DateOfCalculation = DateTime.Now
            };

            SaveCalculation(calculation, false);

            bool anotherCalculation = _displayCRUD.DisplayCalculationResult(operatorChoice, number1, number2, result);

            if (anotherCalculation)
            {
                StartCalculation();
            }
        }

        public void SaveCalculation(CalculatorModel calculatorModel, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.CalculatorModels.Update(calculatorModel);
            }
            else
            {
                _dbContext.CalculatorModels.Add(calculatorModel);
            }
            _dbContext.SaveChanges();
        }

        public void ReadAllCalculations()
        {
            var calculations = GetAllCalculations();
            _displayCRUD.DisplayReadCalculations(calculations);
        }

        public List<CalculatorModel> GetAllCalculations()
        {
            return _dbContext.CalculatorModels.ToList();
        }

        public void UpdateCalculation()
        {
            var existingCalculation = _displayCRUD.DisplaySelectCalculation(GetAllCalculations());
            var calculatorUpdateInput = _displayCRUD.GetUpdatedCalculatorInput(existingCalculation);

            var result = calculatorUpdateInput.Operator switch
            {
                "+" => _additionStrategy.Execute((decimal)calculatorUpdateInput.Number1, calculatorUpdateInput.Number2),
                "-" => _subtractionStrategy.Execute((decimal)calculatorUpdateInput.Number1, calculatorUpdateInput.Number2),
                "*" => _multiplicationStrategy.Execute((decimal)calculatorUpdateInput.Number1, calculatorUpdateInput.Number2),
                "/" => _divisionStrategy.Execute((decimal)calculatorUpdateInput.Number1, calculatorUpdateInput.Number2),
                "%" => _modulusStrategy.Execute((decimal)calculatorUpdateInput.Number1, calculatorUpdateInput.Number2),
                "√" => _squareRootStrategy.Execute((decimal)calculatorUpdateInput.Number1, calculatorUpdateInput.Number2),
                _ => throw new InvalidOperationException("Invalid operator")
            };

            if (existingCalculation != null)
            {
                existingCalculation.Operator = calculatorUpdateInput.Operator;
                existingCalculation.Number1 = (decimal)calculatorUpdateInput.Number1;
                existingCalculation.Number2 = calculatorUpdateInput.Number2;
                existingCalculation.Result = result;
                existingCalculation.DateOfCalculation = DateTime.Now;

                SaveCalculation(existingCalculation, true);

                _displayCRUD.DisplayCalculator(existingCalculation);
            }

        }

        public void DeleteCalculation()
        {
            var calculation = SelectOneCalculation();
            if (calculation == null)
            {
                AnsiConsole.MarkupLine("[red]Calculation not found. Press any key to go back to the menu...[/]");
                Console.ReadKey(true);
                return;
            }

            AnsiConsole.MarkupLine($"[yellow]Are you sure you want to delete the calculation with ID {calculation.CalculatorModelId}? (y/n)[/]");
            var confirmation = AnsiConsole.Prompt(
                new TextPrompt<string>("Press [green]y[/] to confirm or [red]n[/] to cancel:")
                    .AllowEmpty()
                    .Validate(input => input.ToLower() == "y" || input.ToLower() == "n"
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[red]Invalid input, please enter 'y' or 'n'.[/]"))
            );

            if (confirmation.ToLower() != "y")
            {
                AnsiConsole.MarkupLine("[red]Calculation deletion cancelled.[/]");
                AnsiConsole.MarkupLine("[green]Press any key to go back to the menu...[/]");
                Console.ReadKey(true);
                return;
            }

            _dbContext.CalculatorModels.Remove(calculation);
            _dbContext.SaveChanges();
            AnsiConsole.MarkupLine($"[green]Calculation with ID {calculation.CalculatorModelId} deleted successfully![/]");
            AnsiConsole.MarkupLine("[green]Press any key to go back to the menu...[/]");
            Console.ReadKey(true);
        }

        public CalculatorModel SelectOneCalculation()
        {
            var calculationList = GetAllCalculations();

            if (calculationList.Count == 0)
            {
                return null;
            }

            CalculatorModel selectedCalculation = _displayCRUD.DisplaySelectCalculation(calculationList);
            return selectedCalculation;
        }
    }
}
