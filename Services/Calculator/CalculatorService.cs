using Azure;
using DataAccessLayer.Models;
using Services.Calculator.Interfaces;
using Services.Calculator.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IInputReader _inputReader;
        private readonly IDisplayCRUD _displayCRUD;

        // Declare instances of the strategies  
        private readonly AdditionStrategy _additionStrategy;
        private readonly SubtractionStrategy _subtractionStrategy;
        private readonly MultiplicationStrategy _multiplicationStrategy;
        private readonly DivisionStrategy _divisionStrategy;
        private readonly ModulusStrategy _modulusStrategy;
        private readonly SquareRootStrategy _squareRootStrategy;

        public CalculatorService(IInputReader inputReader, IDisplayCRUD displayCRUD)
        {
            _inputReader = inputReader;
            _displayCRUD = displayCRUD;

            // Initialize the strategy instances  
            _additionStrategy = new AdditionStrategy();
            _subtractionStrategy = new SubtractionStrategy();
            _multiplicationStrategy = new MultiplicationStrategy();
            _divisionStrategy = new DivisionStrategy();
            _modulusStrategy = new ModulusStrategy();
            _squareRootStrategy = new SquareRootStrategy();
        }

        public void StartCalculation()
        {
            string[] availableOperators = { "+", "-", "*", "/", "%", "√" };
            var (operatorChoice, number1, number2) = _inputReader.GetCalculationInput(availableOperators);

            var result = operatorChoice switch
            {
                "+" => _additionStrategy.Execute(number1, number2 ?? 0),
                "-" => _subtractionStrategy.Execute(number1, number2 ?? 0),
                "*" => _multiplicationStrategy.Execute(number1, number2 ?? 0),
                "/" => _divisionStrategy.Execute(number1, number2 ?? 0),
                "%" => _modulusStrategy.Execute(number1, number2 ?? 0),
                "√" => _squareRootStrategy.Execute(number1),
                _ => throw new InvalidOperationException("Invalid operator")
            };

            var calculation = new CalculatorModel
            {
                Operator = operatorChoice,
                Number1 = number1,
                Number2 = number2 ?? 0,
                Result = result,
                DateOfCalculation = DateTime.Now
            };

            bool anotherCalculation = _displayCRUD.DisplayCalculationResult(operatorChoice, number1, number2, result);
            
            if (anotherCalculation)
            {
                StartCalculation(); // Recursively call to start a new calculation
            }

        }
    }
}
