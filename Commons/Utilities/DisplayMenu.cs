using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Commons.Utilities
{
    public class DisplayMenu : IDisplayMenu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        private string Title;


        public DisplayMenu(string title, string prompt, string[] options)
        {
            if (title == "Rock, Paper, Scissor")
            {
                title = "RPS";
            }
            if (title == "Calculator")
            {
                title = "Calculate";
            }
            Title = title;
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        public string Run()
        {
            string fontPath;
            Console.Clear();
            if (Title == "Welcome" || Title == "Shapes" || Title == "Calculate" || Title == "RPS")
            {
                fontPath = "../../../../Commons/Assets/Electronic.flf";
            }
            else
            {
                fontPath = "../../../../Commons/Assets/ANSI Regular.flf";
            }

            var font = FigletFont.Load(fontPath);
            var highlightStyle = new Style().Foreground(Color.Fuchsia);

            
            AnsiConsole.Write(
                new FigletText(font, Title)
                .Centered()
                .Color(Color.DeepPink4));

            Console.WriteLine(Prompt);

            var input = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[Fuchsia]Select an option:[/]")
                    .PageSize(10)
                    .HighlightStyle(highlightStyle)
                    .AddChoices(Options));

            return input;
        }
    }
}
