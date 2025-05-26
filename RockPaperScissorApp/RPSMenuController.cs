using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.Interfaces;
using Commons.Utilities;

namespace RockPaperScissorApp
{
    public class RPSMenuController
    {
        private readonly IMenuService _menuService;

        public RPSMenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public void RunRPSMenu()
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
                        //DisplayGameRules();
                        break;
                    case "View Game History":
                        //ViewGameHistory();
                        break;
                    case "Exit":
                        return;
                }
            }
        }
    }
}
