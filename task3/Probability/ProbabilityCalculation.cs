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
                        (int wins1, int wins2) = CompareDice(diceList[i], diceList[j]);
                        double totalBattles = wins1 + wins2;
                        winProbabilities[i, j] = totalBattles == 0 ? 0.5 : wins1 / totalBattles;
                    }
                }
            }

            return winProbabilities;
        }

        private static (int, int) CompareDice(Dice dice1, Dice dice2)
        {
            int wins1 = 0, wins2 = 0;

            foreach (int value1 in dice1.values)
            {
                foreach (int value2 in dice2.values)
                {
                    if (value1 > value2) wins1++;
                    else if (value2 > value1) wins2++;
                }
            }

            return (wins1, wins2);
        }
    }
}
