﻿using Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IMenuService
    {
        DisplayMenu CreateMainMenu();
        DisplayMenu CreateShapesMenu();
    }
}
