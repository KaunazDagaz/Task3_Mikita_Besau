using Spectre.Console;

namespace task3
{
    internal class UserInterface : IUserInterface
    {
        private readonly ISelectionTable selectionTable;
        public UserInterface(ISelectionTable selectionTable)
        {
            this.selectionTable = selectionTable;
        }

        public bool GetFirstMoveDecision(CryptoRandomGenerator cryptoRandomGenerator)
        {
            AnsiConsole.WriteLine("I selected a random value in the range 0..1 ");
            AnsiConsole.WriteLine($"(HMAC:{Convert.ToHexString(cryptoRandomGenerator.CalculateHMAC())})");

            int userGuess = selectionTable.DisplayFirstMoveSelectionMenu();

            AnsiConsole.WriteLine($"Your selection: {userGuess}");
            AnsiConsole.WriteLine($"My selection: {cryptoRandomGenerator.num} (KEY={Convert.ToHexString(cryptoRandomGenerator.key)}).\n");

            return userGuess == cryptoRandomGenerator.num;
        }

        public Dice GetUserSelectedDice(List<Dice> diceList)
        {
            var diceNames = diceList.Select(d => string.Join(",", d.values)).ToArray();
            int selectedDiceIndex = selectionTable.DisplayDiceSelectionMenu(diceNames);
            var selectedDice = diceList[selectedDiceIndex];
            diceList.RemoveAt(selectedDiceIndex);
            AnsiConsole.WriteLine($"You choose the [{string.Join(",", selectedDice.values)}] dice.");
            return selectedDice;
        }

        public Dice GetComputerSelectedDice(List<Dice> diceList, CryptoRandomGenerator cryptoRandomGenerator)
        {
            int selectedIndex = cryptoRandomGenerator.num;
            var selectedDice = diceList[selectedIndex];
            AnsiConsole.WriteLine($"I choose the [{string.Join(",", selectedDice.values)}] dice.");
            diceList.RemoveAt(selectedIndex);
            return selectedDice;
        }

        public int GetDiceThrowResult(Dice dice, CryptoRandomGenerator cryptoRandomGenerator)
        {
            int computerNumber = cryptoRandomGenerator.num;

            AnsiConsole.WriteLine($"I selected a random value in the range 0..{dice.values.Count - 1} ");
            AnsiConsole.WriteLine($"(HMAC:{Convert.ToHexString(cryptoRandomGenerator.CalculateHMAC())})");

            int userNumber = selectionTable.DisplayNumberSelectionMenu(dice.values.Count);

            AnsiConsole.WriteLine($"Your selection: {userNumber}");
            AnsiConsole.WriteLine($"My number is {computerNumber} (KEY={Convert.ToHexString(cryptoRandomGenerator.key)}).");

            int result = (userNumber + computerNumber) % dice.values.Count;
            AnsiConsole.WriteLine($"The result is {userNumber} + {computerNumber} = {result} (mod {dice.values.Count}).");

            int throwResult = dice.values[result];
            AnsiConsole.WriteLine($"The throw result is {throwResult}.\n");
            return throwResult;
        }

        public void ShowWinner(int userResult, int computerResult)
        {
            if (userResult > computerResult)
            {
                AnsiConsole.Markup($"[green]You win ({userResult} > {computerResult})![/]");
            }
            else if (userResult < computerResult)
            {
                AnsiConsole.Markup($"[red]I win ({computerResult} > {userResult})![/]");
            }
            else
            {
                AnsiConsole.Markup($"[yellow]It's a draw ({userResult} = {computerResult})![/]");
            }
        }
    }
}
