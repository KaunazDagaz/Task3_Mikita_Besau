using Spectre.Console;

namespace task3
{
    internal static class DiceParser
    {
        public static bool TryParse(string[] args, List<Dice> diceList)
        {
            if (!ValidateDiceCount(args)) return false;
            int expectedLength = 0;

            foreach (var arg in args)
            {
                var numbers = arg.Split(',');

                int currentLength = numbers.Length;
                if (expectedLength == 0)
                {
                    expectedLength = currentLength;
                }

                if (!ValidateDiceLength(expectedLength, currentLength)) return false;
                if (!ValidateDiceConfiguration(numbers, arg)) return false;

                var values = numbers.Select(n => int.Parse(n));
                var dice = new Dice(values);
                diceList.Add(dice);
            }

            return true;

        }

        private static bool ValidateDiceCount(string[] args)
        {
            if (args.Length < 3)
            {
                AnsiConsole.Markup("[red]Error: At least three dice configurations are required.\n[/]");
                AnsiConsole.Markup("[red]Example: dotnet run 2,2,4,4,5,5 6,3,1,1,2,6 5,5,3,2,4,3\n[/]");
                return false;
            }

            return true;
        }

        private static bool ValidateDiceLength(int expectedLength, int currentLength)
        {
            if (expectedLength != 0 && currentLength != expectedLength)
            {
                AnsiConsole.Markup("[red]Error: All dice must have the same number of sides.\n[/]");
                return false;
            }

            return true;
        }

        private static bool ValidateDiceConfiguration(string[] numbers, string arg)
        {
            if (!numbers.All(n => int.TryParse(n, out int value)))
            {
                AnsiConsole.Markup($"[red]Error: Invalid format in argument {arg}. Each argument must contain only comma-separated integers.\n[/]");
                AnsiConsole.Markup("[red]Example: dotnet run 2,2,4,4,5,5 6,3,1,1,2,6 5,5,3,2,4,3\n[/]");
                return false;
            }

            return true;
        }
    }
}       