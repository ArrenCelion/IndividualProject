using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Commons.Interfaces;

namespace Commons.Utilities
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

        /*----- SHAPES -----*/

        public DisplayMenu SelectShapesMenu()
        {
            string title = "Shapes";
            string[] options = { "Rectangle", "Parallelogram", "Rhombus", "Triangle", "Read all Shapes", "Back" };
            string prompt = "Choose a shape to calculate or read all shapes";
            return new DisplayMenu(title, prompt, options);
        }

        public DisplayMenu CrudShapesMenu(string input)
        {
            string title = input;
            string[] options = { "Calculate Shape", "Read all", "Update", "Delete", "Back" };
            string prompt = $"Calculate Shape or CRUD {input}";
            return new DisplayMenu(title, prompt, options);
        }

        /*----- ROCK PAPER SCISSOR -----*/

        public DisplayMenu SelectRPSMenu()
        {
            string title = "Rock, Paper, Scissor";
            string[] options = { "Play Game", "Game Rules", "View Game History", "Exit" };
            string prompt = "Choose an option to play or view game history";
            return new DisplayMenu(title, prompt, options);
        }
    }
}
