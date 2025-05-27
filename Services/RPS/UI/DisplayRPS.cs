using Services.RPS.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RPS.UI
{
    public class DisplayRPS : IDisplayRPS
    {
        public void DisplayGameResult(string result, string playerHand, string computerHand)
        {
            Console.Clear();
            AnsiConsole.MarkupLine($"[bold]Player Hand:[/] [aqua]{playerHand}[/]");
            AnsiConsole.MarkupLine($"[bold]Computer Hand:[/] [blue]{computerHand}[/]");

            switch (result)
            {
                case "Tie":
                    AnsiConsole.MarkupLine("[bold orange1]It's a Tie![/]");
                    break;
                case "Player Win":
                    AnsiConsole.MarkupLine("[bold green]You win![/]");
                    break;
                case "Computer Win":
                    AnsiConsole.MarkupLine("[bold red]Computer wins![/]");
                    break;
                default:
                    break;
            }

            AnsiConsole.MarkupLine($"[bold]Date of Game:[/] [grey]{DateTime.Now:MM/dd/yyyy HH:mm:ss}[/]");
            AnsiConsole.MarkupLine("[bold]Press any key to go back to the menu...[/]");
            Console.ReadKey(true);
        }

        public void DisplayGameRules()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold Fuchsia]Game Rules:[/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine("Pick your hand in the Game Menu, the Computers hand will be randomized");
            AnsiConsole.MarkupLine("1. Rock beats Scissors.");
            AnsiConsole.MarkupLine("2. Scissors beat Paper.");
            AnsiConsole.MarkupLine("3. Paper beats Rock.");
            AnsiConsole.MarkupLine("4. If both players choose the same hand, it's a tie.");
            Console.WriteLine();
            AnsiConsole.MarkupLine("[bold]Press any key to continue...[/]");
            Console.ReadKey(true);
            

        }
    }
}
