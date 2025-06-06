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
        private readonly ICalcDisplayCRUD _displayCRUD;
        private readonly ICalculatorService _calculatorService;

        public CalculatorMenuController(IMenuService menuService, ICalcDisplayCRUD displayCRUD, ICalculatorService calculatorService)
        {
            _menuService = menuService;
            _displayCRUD = displayCRUD;
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
                    case "Edit":
                        //_displayCRUD.UpdateCalculation();
                        break;
                    case "Delete":
                        //_displayCRUD.DeleteCalculation(); //TODO: Hard Delete, fix soft delete?
                        break;
                    case "Back":
                        return;
                    default:
                        break;
                }
            }
        }

        //public void RunShapesCrudMenu(string input)
        //{
        //    while (true)
        //    {
        //        var menu = _menuService.CrudShapesMenu(input);
        //        var choice = menu.Run();
        //        switch (choice)
        //        {
        //            case "Calculate Shape":
        //                _shapeService.CalculateShape(input);
        //                break;
        //            case "Read all":
        //                _shapeService.ReadWhatShapes(input);
        //                break;
        //            case "Update":
        //                _shapeService.UpdateShape(input);
        //                break;
        //            case "Delete":
        //                _shapeService.DeleteShape(input); //TODO: Hard Delete, fix soft delete?
        //                break;
        //            case "Back":
        //                return;
        //        }
        //    }
        //}
    }
}
