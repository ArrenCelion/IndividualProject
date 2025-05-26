using Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorApp
{
    public class RPSMenuController
    {
        private readonly IMenuService _menuService;

        public RPSMenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public void RunShapesMenu()
        {
            while (true)
            {
                var menu = _menuService.SelectRPSMenu();
                var input = menu.Run();
                switch (input)
                {
                    case "Play Game":
                        //PlayGame();
                        break;
                    case "Game Rules":
                        //ReadGameRules();
                        break;
                    case "Read all Games":
                        //ReadAllGames();
                        break;
                    case "Exit":
                        return;
                }
            }
        }
    }
}
