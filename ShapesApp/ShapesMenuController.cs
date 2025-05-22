using Common.Interfaces;
using Commons;
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

        public ShapesMenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public void RunShapesMenu()
        {
            while (true)
            {
                var menu = _menuService.CreateShapesMenu();
                var choice = menu.Run();

                switch (choice)
                {
                    case "Rectangle":
                        Console.WriteLine("Rectangle selected");
                        Console.ReadLine();
                        break;
                    case "Back":
                        return;
                }
            }
        }
    }
}
