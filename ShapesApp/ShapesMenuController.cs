using Commons.Interfaces;
using Commons;
using Services.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    public class ShapesMenuController
    {
        private readonly IMenuService _menuService;
        private readonly IShapeService _shapeService;
        private readonly IDisplayCRUD _displayCRUD;

        public ShapesMenuController(IMenuService menuService, IShapeService shapeService, IDisplayCRUD displayCRUD)
        {
            _menuService = menuService;
            _shapeService = shapeService;
            _displayCRUD = displayCRUD;
        }

        public void RunShapesMenu()
        {
            while (true)
            {
                var menu = _menuService.SelectShapesMenu();
                var input = menu.Run();

                

                switch (input)
                {
                    case "Rectangle":
                    case "Parallelogram":
                    case "Rhombus":
                    case "Triangle":
                        RunShapesCrudMenu(input);
                        break;
                    case "Read all Shapes":
                        _shapeService.ReadWhatShapes("All Shapes");
                        break;
                    case "Back":
                        return;
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
                        // Call the method to update a shape
                        break;
                    case "Delete":
                        // Call the method to delete a shape
                        break;
                    case "Back":
                        return;
                }
            }
        }
    }
}
