using DataAccessLayer.DTOs;
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
        void CalculateParallelogram(string shape);
        void SaveShape(ShapesModel model, bool isUpdate);
        List<ShapesModel> ReadAllSpecificShape(string shapeName);
        List<ShapesModel> ReadAllShapes();
        void ReadWhatShapes(string shape);
        void ApplyShapeUpdates(ShapesModel shape, ShapeUpdateInput input);
        ShapesModel SelectOneShape(string shapeName);
        void UpdateShape(string shapeName);

    }
}
