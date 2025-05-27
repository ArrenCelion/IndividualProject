using Commons.Interfaces;
using Services.RPS.Interfaces;
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
        private readonly IRPSService _rpsService;
        private readonly IDisplayRPS _displayRPS;

        public RPSMenuController(IMenuService menuService, IRPSService rpsService, IDisplayRPS displayRPS)
        {
            _menuService = menuService;
            _rpsService = rpsService;
            _displayRPS = displayRPS;
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
                        _rpsService.PlayGame();
                        break;
                    case "Game Rules":
                        _displayRPS.DisplayGameRules();
                        break;
                    case "Read all Games":
                        _rpsService.ReadAllGames();
                        break;
                    case "Exit":
                        return;
                }
            }
        }
    }
}
