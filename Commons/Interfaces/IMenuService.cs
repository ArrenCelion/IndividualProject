using Commons.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Interfaces
{
    public interface IMenuService
    {
        DisplayMenu CreateMainMenu();
        DisplayMenu CrudShapesMenu(string input);
        DisplayMenu SelectShapesMenu();
        DisplayMenu SelectRPSMenu();
        DisplayMenu SelectCalcMenu();
    }
}
