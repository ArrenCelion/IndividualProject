using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Common.Utilities
{
    public class DisplayMenu : IDisplayMenu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        private string Title;


        public DisplayMenu(string title, string prompt, string[] options)
        {
            Title = title;
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        public string Run()
        {
            Console.Clear();
            var font = FigletFont.Load("../Assets/Electronic.flf");

            AnsiConsole.Write(
                new FigletText(font, Title)
                .Centered()
                .Color(Color.DeepPink4));

            Console.WriteLine(Prompt);

            var input = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[deeppink4_1]Select an option:[/]")
                    .PageSize(10)
                    .AddChoices(Options));

            return input;
        }
    }
}
