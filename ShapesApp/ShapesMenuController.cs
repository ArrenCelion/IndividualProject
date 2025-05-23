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

        public ShapesMenuController(IMenuService menuService, IShapeService shapeService)
        {
            _menuService = menuService;
            _shapeService = shapeService;
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
                    case "Read One":
                        // Call the method to read one shape
                        break;
                    case "Read all":
                        // Call the method to read all shapes
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
