using Services.Calculator.Interfaces;
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
        public CalculatorService(IInputReader inputReader, IDisplayCRUD displayCRUD)
        {
            _inputReader = inputReader;
            _displayCRUD = displayCRUD;
        }


    }
}
