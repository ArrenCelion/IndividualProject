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
        object DisplaySelectShape(List<object> shapeList);
        void DisplayUpdateShape(int shapeId, string shape);
    }
}
    