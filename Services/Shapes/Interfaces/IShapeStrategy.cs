using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.Interfaces
{
    public interface IShapeStrategy<TParams>
    {
        string ShapeName { get; }

        double CalculateArea(TParams parameters);
        double CalculateCircumference(TParams parameters);
    }
}
