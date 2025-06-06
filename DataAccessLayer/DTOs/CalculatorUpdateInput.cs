using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class CalculatorUpdateInput
    {
        public decimal? Number1 { get; set; }
        public decimal? Number2 { get; set; }
        public string? Operator { get; set; }
    }
}
