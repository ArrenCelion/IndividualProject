using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class RectangleModel
    {
        public int RectangleModelId { get; set; }
        public decimal Base { get; set; }
        public decimal Height { get; set; }
        public decimal Area { get; set; }
        public decimal Circumference { get; set; }
        public DateOnly DateOfCalculation { get; set; }
    }
}
