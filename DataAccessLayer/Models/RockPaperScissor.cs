using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class RockPaperScissor
    {
        public int RockPaperScissorId { get; set; }
        public string PlayerHand { get; set; }
        public string ComputerHand { get; set; }
        public string Result { get; set; }
        public DateTime DateOfGame { get; set; }
        public decimal GamesWonAverage { get; set; }
    }
}
