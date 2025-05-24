using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
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
        void SaveParallelogram(Parallelogram parallelogramModel);

        void SaveRectangle(RectangleModel rectangleModel);
        void SaveTriangle(Triangle triangleModel);
        // ReadOneShape(string shapeName, int id);
        List<string> ReadAllRectangles();
        List<string> ReadAllTriangles();
        List<string> ReadAllParallelograms(string shapeType);
        List<string> ReadAllShapes();
    }
}
