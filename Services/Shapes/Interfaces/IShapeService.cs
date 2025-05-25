using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.Interfaces
{
    public interface IShapeService
    {
        void CalculateShape(string input);
        void CalculateRectangle();
        void CalculateTriangle();
        void CalculateParallelogram();
        void SaveShape(ShapesModel model);
        // ReadOneShape(string shapeName, int id);
        void ReadAllSpecificShape(string shapeName);
        void ReadAllShapes();
        void ReadWhatShapes(string shape);
    }
}
