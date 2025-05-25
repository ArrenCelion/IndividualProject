using DataAccessLayer.DTOs;
using Services.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.Strategies
{
    public class ParallelogramStrategy : IShapeStrategy<ParallelogramDTO>
    {
        public string ShapeName => "Parallelogram";

        public double CalculateArea(ParallelogramDTO dto) =>
            (double)(dto.Base * dto.Height);

        public double CalculateCircumference(ParallelogramDTO dto) =>
            2 * (double)(dto.Base + dto.SideA);
    }
}
