using DataAccessLayer.Models;
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
        public bool DisplayGameResult(RockPaperScissor game)
        {
            Console.Clear();
            AnsiConsole.MarkupLine($"[bold]Player Hand:[/] [aqua]{game.PlayerHand}[/]");
            AnsiConsole.MarkupLine($"[bold]Computer Hand:[/] [blue]{game.ComputerHand}[/]");

            switch (game.Result)
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
            }

            var table = new Table();
            table.Border = TableBorder.Rounded;
            table.AddColumn("[yellow]Player Hand[/]");
            table.AddColumn("[yellow]Computer Hand[/]");
            table.AddColumn("[yellow]Result[/]");
            table.AddColumn("[yellow]Date[/]");
            table.AddColumn("[yellow]Win Ratio[/]");

            table.AddRow(
                $"[aqua]{game.PlayerHand}[/]",
                $"[blue]{game.ComputerHand}[/]",
                game.Result switch
                {
                    "Tie" => "[orange1]It's a Tie![/]",
                    "Player Win" => "[green]You win![/]",
                    "Computer Win" => "[red]Computer wins![/]",
                    _ => game.Result
                },
                $"[grey]{game.DateOfGame:yyyy-MM-dd}[/]",
                $"[bold]{game.GamesWonAverage:P2}[/]"
            );

            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine("[yellow]Would you like to play again?[/] (y/n)");
            var anotherGame = AnsiConsole.Prompt(new TextPrompt<string>("Press [green]y[/] to play again or [red]n[/] to exit to menu:")
                .AllowEmpty().Validate(input => input.ToLower() == "y" || input.ToLower() == "n" ? ValidationResult.Success() : ValidationResult.Error("[red]Invalid input, please enter 'y' or 'n'.[/]")));
            return anotherGame.ToLower() == "y";
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
