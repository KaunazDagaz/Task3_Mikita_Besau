namespace task3
{
    internal static class ProbabilityCalculation
    {
        public static double[,] CalculateWinningProbabilities(List<Dice> diceList)
        {
            int numDice = diceList.Count;
            double[,] winProbabilities = new double[numDice, numDice];

            for (int i = 0; i < numDice; i++)
            {
                for (int j = 0; j < numDice; j++)
                {
                    if (i != j)
                    {
                        int wins1 = CompareDice(diceList[i], diceList[j]);
                        int totalBattles = diceList[i].values.Count * diceList[j].values.Count;
                        winProbabilities[i, j] = totalBattles = wins1 / totalBattles;
                    }
                }
            }

            return winProbabilities;
        }

        private static int CompareDice(Dice dice1, Dice dice2)
        {
            return dice1.values.SelectMany(_ => dice2.values, (value1, value2) => value1 > value2).Count(value1 => value1);
        }
    }
}
