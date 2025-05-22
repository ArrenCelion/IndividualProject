using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Parallelogram
    {
        public int ParallelogramId { get; set; }
        public decimal Base { get; set; }
        public decimal Height { get; set; }
        public decimal Side { get; set; }
        public decimal Area { get; set; }
        public decimal Circumference { get; set; }
        public DateOnly DateOfCalculation { get; set; }
        public bool IsRhombus { get; set; }
    }
}
