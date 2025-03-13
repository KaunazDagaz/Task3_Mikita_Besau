using Spectre.Console;

namespace task3
{
    internal static class ProbabilityTable
    {
        static double[,]? probabilities;
        static List<Dice>? diceList;

        public static void Initialize(List<Dice> diceList, double[,] probabilities)
        {
            ProbabilityTable.diceList = diceList;
            ProbabilityTable.probabilities = probabilities;
        }

        public static void DisplayProbabilityTable()
        {
            var table = new Table();

            if (probabilities == null || diceList == null)
            {
                table.AddColumn("Dice \\ Dice");
                AnsiConsole.Write(table);
                return;
            }

            int numDice = probabilities.GetLength(0);

            List<string> diceLabels = diceList
                .Select(d => $"[[{string.Join(",", d.values)}]]")
                .ToList();

            table.AddColumn("Dice \\ Dice");
            foreach (var label in diceLabels)
            {
                table.AddColumn(label);
            }

            for (int i = 0; i < numDice; i++)
            {
                var row = new List<string> { diceLabels[i] };
                for (int j = 0; j < numDice; j++)
                {
                    if (i == j)
                    {
                        row.Add("-");
                    }
                    else
                    {
                        string probability = probabilities[i, j].ToString("0.00");
                        row.Add(probability);
                    }
                }
                table.AddRow(row.ToArray());
            }

            AnsiConsole.Write(table);
        }
    }
}