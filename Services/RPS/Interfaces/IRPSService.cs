using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RPS.Interfaces
{
    public interface IRPSService
    {
        void PlayGame();
        string RandomizeComputerHand();
        string GetPlayerHand();
        decimal GetGamesAverage();
    }
}
