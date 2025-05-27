using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RPS.Interfaces
{
    public interface IDisplayRPS
    {
        void DisplayGameResult(string result, string playerHand, string computerHand);
    }
}
