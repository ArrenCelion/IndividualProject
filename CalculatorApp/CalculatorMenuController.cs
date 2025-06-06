using Commons.Interfaces;
using Services.Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class CalculatorMenuController
    {
        private readonly IMenuService _menuService;
        private readonly ICalculatorService _calculatorService;

        public CalculatorMenuController(IMenuService menuService, ICalculatorService calculatorService)
        {
            _menuService = menuService;
            _calculatorService = calculatorService;
        }

        public void RunCalculatorMenu()
        {
            while (true)
            {
                var menu = _menuService.SelectCalcMenu();
                var input = menu.Run();

                switch (input)
                {
                    case "New calculation":
                        _calculatorService.StartCalculation();
                        break;
                    case "Read all":
                        _calculatorService.ReadAllCalculations();
                        break;
                    case "Update":
                        _calculatorService.UpdateCalculation();
                        break;
                    case "Delete":
                        _calculatorService.DeleteCalculation();
                        break;
                    case "Back":
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
