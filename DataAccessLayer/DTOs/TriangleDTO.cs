using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class TriangleDTO
    {
        public decimal Base { get; set; }
        public decimal Height { get; set; }
        public decimal SideA { get; set; }
        public decimal SideB { get; set; }
        public decimal SideC { get; set; }
    }
}
