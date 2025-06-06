using Azure;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
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
    }
}
