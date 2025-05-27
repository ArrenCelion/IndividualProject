using Services.RPS.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RPS.UI
{
    public class InputReaderRPS : IInputReaderRPS
    {
        public string GetPlayerInput()
        {
            var input = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose your move:")
                    .PageSize(3)
                    .HighlightStyle(new Style().Foreground(Color.Fuchsia))
                    .AddChoices("Rock", "Paper", "Scissor")
            );
            return input;
        }
    }
}
