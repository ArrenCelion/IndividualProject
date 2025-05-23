using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shapes.Interfaces
{
    public interface IDisplayResult
    {
        void DisplayRectangle(string shapeName, RectangleModel model);
    }
}
