using DataAccessLayer.DTOs;
using Services.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.Strategies
{
    public class RectangleStrategy : IShapeStrategy<RectangleDTO>
    {
        public string ShapeName => "Rectangle";

        public double CalculateArea(RectangleDTO dto) =>
            (double)(dto.Base * dto.Height);

        public double CalculateCircumference(RectangleDTO dto) =>
            2 * (double)(dto.Base + dto.Height);
    }
}
