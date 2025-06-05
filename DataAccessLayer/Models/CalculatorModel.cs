using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CalculatorModel
    {
        public int CalculatorModelId { get; set; }
        public decimal Number1 { get; set; }
        public decimal? Number2 { get; set; }
        public decimal Result { get; set; }
        public string Operator { get; set; } = string.Empty;
        public DateTime DateOfCalculation { get; set; }
        
    }
}
