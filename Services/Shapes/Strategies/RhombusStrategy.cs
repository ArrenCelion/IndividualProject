using DataAccessLayer.DTOs;
using Services.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.Strategies
{
    public class RhombusStrategy : IShapeStrategy<ParallelogramDTO>
    {
        public string ShapeName => "Rhombus";

        public double CalculateArea(ParallelogramDTO dto) =>
            (double)(dto.Base * dto.Height);

        public double CalculateCircumference(ParallelogramDTO dto) =>
            4 * (double)(dto.SideA);
    }
}
