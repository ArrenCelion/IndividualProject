using DataAccessLayer.DTOs;
using Services.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.Strategies
{
    public class TriangleStrategy : IShapeStrategy<TriangleDTO>
    {
        public string ShapeName => "Triangle";

        public double CalculateArea(TriangleDTO dto) =>
            (double)((dto.Base * dto.Height)/2);

        public double CalculateCircumference(TriangleDTO dto) =>
            (double)(dto.SideA + dto.SideB + dto.SideC);
    }
}
