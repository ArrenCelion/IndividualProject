using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RPS.Interfaces
{
    public interface IDisplayRPS
    {
        bool DisplayGameResult(RockPaperScissor game);
        void DisplayGameRules();
        void DisplayAllGames(List<RockPaperScissor> games);
    }
}
