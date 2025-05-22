using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Calculator
    {
        public int CalculatorId { get; set; }
        public decimal Number1 { get; set; }
        public decimal Number2 { get; set; }
        public decimal Result { get; set; }
        public string Operator { get; set; }
        public DateTime DateOfCalculation { get; set; }

    }
}
