using Commons.Interfaces;
using Services.Shapes.Interfaces;
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
        private readonly IShapeService _shapeService;
        private readonly IDisplayCRUD _displayCRUD;

        public CalculatorMenuController(IMenuService menuService, IShapeService shapeService, IDisplayCRUD displayCRUD)
        {
            _menuService = menuService;
            _shapeService = shapeService;
            _displayCRUD = displayCRUD;
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
                        _displayCRUD.CreateCalculation();
                        break;
                    case "Read all":
                        _displayCRUD.ReadAllCalculations();
                        break;
                    case "Edit":
                        _displayCRUD.UpdateCalculation();
                        break;
                    case "Delete":
                        _displayCRUD.DeleteCalculation(); //TODO: Hard Delete, fix soft delete?
                        break;
                    case "Back":
                        return;
                    default:
                        break;
                }
            }
        }

        public void RunShapesCrudMenu(string input)
        {
            while (true)
            {
                var menu = _menuService.CrudShapesMenu(input);
                var choice = menu.Run();
                switch (choice)
                {
                    case "Calculate Shape":
                        _shapeService.CalculateShape(input);
                        break;
                    case "Read all":
                        _shapeService.ReadWhatShapes(input);
                        break;
                    case "Update":
                        _shapeService.UpdateShape(input);
                        break;
                    case "Delete":
                        _shapeService.DeleteShape(input); //TODO: Hard Delete, fix soft delete?
                        break;
                    case "Back":
                        return;
                }
            }
        }
    }
