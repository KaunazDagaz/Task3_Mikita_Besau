using Spectre.Console;

namespace task3
{
    internal class GameManager
    {
        private List<Dice> diceList;
        private readonly GameHandler gameHandler;

        public GameManager(List<Dice> diceList)
        {
            this.diceList = new List<Dice>(diceList);
            var selectionTable = new SelectionTable();
            var userInterface = new UserInterface(selectionTable);
            gameHandler = new GameHandler(userInterface);
        }

        public void Play()
        {
            AnsiConsole.WriteLine("Let's determine who makes the first move.");
            bool isUserMovesFirst = gameHandler.DetermineFirstMove();

            Dice userDice, computerDice;
            int userResult, computerResult;

            if (isUserMovesFirst)
            {
                AnsiConsole.WriteLine("You make the first move.");
                userDice = gameHandler.UserSelectDice(diceList);
                computerDice = gameHandler.ComputerSelectDice(diceList);
            }
            else
            {
                AnsiConsole.WriteLine("I make the first move.");
                computerDice = gameHandler.ComputerSelectDice(diceList);
                userDice = gameHandler.UserSelectDice(diceList);
            }

            AnsiConsole.WriteLine("Throwing my dice");
            computerResult = gameHandler.PerformThrow(computerDice);
            AnsiConsole.WriteLine("Throwing your dice");
            userResult = gameHandler.PerformThrow(userDice);

            gameHandler.DisplayWinner(userResult, computerResult);
        }
    }
}
