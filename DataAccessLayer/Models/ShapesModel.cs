using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ShapesModel
    {
        public int ShapesModelId { get; set; }
        public string ShapeName { get; set; } = String.Empty;
        public decimal Base { get; set; }
        public decimal Height { get; set; }
        public decimal? SideA { get; set; }
        public decimal? SideB { get; set; }
        public decimal? SideC { get; set; }
        public decimal Area { get; set; }
        public decimal Circumference { get; set; }
        public DateOnly DateOfCalculation { get; set; } //TODO: Change to DateTime if you need time precision
    }
}
