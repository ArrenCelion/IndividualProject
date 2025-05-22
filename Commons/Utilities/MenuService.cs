using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Utilities;

namespace Services
{
    public class MenuService : IMenuService 
    {
        public DisplayMenu CreateMainMenu()
        {
            string title = "Welcome";
            string[] options = { "Shapes", "Calculator", "Rock, Paper, Scissor", "Exit" };
            string prompt = "Welcome to the Triple Project!";
            return new DisplayMenu(title, prompt, options);
        }

        public DisplayMenu CreateShapesMenu()
        {
            string title = "Shapes";
            string[] options = { "Rectangle", "Parallelogram", "Rhombus", "Triangle", "Back" };
            string prompt = "Choose a shape to calculate";
            return new DisplayMenu(title, prompt, options);
        }
    }
}
