using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.Interfaces
{
    public interface IDisplayCRUD
    {
        void DisplayReadShapes(List<ShapesModel> shape);
        ShapesModel DisplaySelectShape(List<ShapesModel> shapeList);
        ShapeUpdateInput GetUpdatedShapeInput(ShapesModel shape);
        void DisplayShape(ShapesModel model);
    }
}
    