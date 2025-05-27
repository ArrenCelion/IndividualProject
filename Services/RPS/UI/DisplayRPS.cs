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
    }
}
