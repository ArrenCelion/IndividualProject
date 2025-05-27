using DataAccessLayer;
using Services.RPS.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RPS
{
    public class RPSService : IRPSService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IInputReaderRPS _inputReader;
        private readonly IDisplayRPS _displayRPS;

        public RPSService(ApplicationDbContext dbContext, IInputReaderRPS inputReader, IDisplayRPS displayRPS)
        {
            _dbContext = dbContext;
            _inputReader = inputReader;
            _displayRPS = displayRPS;
        }

        public void PlayGame()
        {
            string playerHand = GetPlayerHand();
            string computerHand = RandomizeComputerHand();

            string result;
            if (playerHand == computerHand)
            {
                result = "Tie";
                //Should you play again?
            }
            else if (
                (playerHand == "Rock" && computerHand == "Scissor") ||
                (playerHand == "Scissor" && computerHand == "Paper") ||
                (playerHand == "Paper" && computerHand == "Rock"))
            {
                result = "Player Win";
            }
            else
            {
                result = "Computer Win";
            }

            _displayRPS.DisplayGameResult(result, playerHand, computerHand);
        }

        public string RandomizeComputerHand()
        {
            var computerHand = string.Empty;
            var random = new Random();
            var input = random.Next(1, 4);
            switch (input)
            {
                case 1:
                    return computerHand = "Rock";
                    break;
                case 2:
                    return computerHand = "Paper";
                    break;
                case 3:
                    return computerHand = "Scissor";
                    break;
                default:
                    break;
            }
            return computerHand;
        }

        public string GetPlayerHand()
        {
            var input = _inputReader.GetPlayerInput();
   
            return input;
        }
    }
}
