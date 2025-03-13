using Spectre.Console;

namespace task3
{
    internal class SelectionTable : ISelectionTable
    {
        public int DisplayFirstMoveSelectionMenu()
        {
            var choices = new List<int> { 0, 1 };
            return DisplaySelectionMenu("Try to guess my selection (0 or 1)", choices);
        }

        public int DisplayDiceSelectionMenu(string[] diceConfigurations)
        {
            var selectedConfig = DisplaySelectionMenu("Choose your dice", diceConfigurations);
            var index = Array.IndexOf(diceConfigurations, selectedConfig);
            return index;
        }

        public int DisplayNumberSelectionMenu(int modulo)
        {
            var choices = Enumerable.Range(0, modulo);
            return DisplaySelectionMenu($"Add your number modulo {modulo}", choices);
        }

        private T? DisplaySelectionMenu<T>(string title, IEnumerable<T> options)
        {
            var optionList = options.ToList();
            var choiceStrings = optionList.Select(o => o?.ToString() ?? string.Empty).ToList();

            choiceStrings.Add("X");
            choiceStrings.Add("?");

            while (true)
            {
                var userChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title($"[green]{title}[/]")
                        .PageSize(choiceStrings.Count)
                        .AddChoices(choiceStrings)
                );

                switch (userChoice)
                {
                    case "X":
                        AnsiConsole.Markup("[red]Exiting...[/]");
                        Environment.Exit(0);
                        return default;
                    case "?":
                        ProbabilityTable.DisplayProbabilityTable();
                        break;
                    default:
                        var index = choiceStrings.IndexOf(userChoice);
                        if (index >= 0 && index < optionList.Count)
                        {
                            return optionList[index];
                        }
                        return default;
                }
            }
        }
    }
}
