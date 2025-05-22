using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleProject
{
    public class MainMenuController
    {
        private readonly IMenuService _menuService;

        public MainMenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public void Run()
        {
            var exit = false;

            while (!exit)
            {
                var menu = _menuService.CreateMainMenu();
                var choice = menu.Run();

                switch (choice)
                {
                    case "Shapes":
                        StartApp("ShapesApp");
                        break;
                    case "Calculator":
                        StartApp("CalculatorApp");
                        break;
                    case "Rock, Paper, Scissor":
                        StartApp("RockPaperScissorApp");
                        break;
                    case "Exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void StartApp(string projectName)
        {
            var targetAppPath = Path.GetFullPath(
                Path.Combine(
                    AppContext.BaseDirectory,
                    $@"..\..\..\..\{projectName}\bin\Debug\net9.0\{projectName}.exe"
                )
            );

            try
            {
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = targetAppPath,
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    WorkingDirectory = Path.GetDirectoryName(targetAppPath)
                });

                if (process != null)
                {
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start project '{projectName}': {ex.Message}");
            }

        }

        //private void StartApp(string projectPath)
        //{
        //    var startInfo = new ProcessStartInfo
        //    {
        //        FileName = "dotnet",
        //        Arguments = $"run --project {projectPath}",
        //        UseShellExecute = false
        //    };

        //    try
        //    {
        //        Process.Start(startInfo);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Failed to start project at '{projectPath}': {ex.Message}");
        //    }
        //}
    }
}
