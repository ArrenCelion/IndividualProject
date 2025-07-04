﻿using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.Interfaces
{
    public interface ICalcDisplayCRUD
    {
        bool DisplayCalculationResult(string operation, decimal number1, decimal? number2, decimal result);
        void DisplayReadCalculations(List<CalculatorModel> calcList);
        CalculatorModel DisplaySelectCalculation(List<CalculatorModel> calcList);
        void DisplayCalculator(CalculatorModel model);
        CalculatorUpdateInput GetUpdatedCalculatorInput(CalculatorModel calc);
    }
}
