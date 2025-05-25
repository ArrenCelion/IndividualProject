using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.Interfaces
{
    public interface IInputReader
    {
        RectangleDTO GetRectangleInput();
        TriangleDTO GetTriangleInput();
        ParallelogramDTO GetParallelogramInput(string shape);
    }
}
