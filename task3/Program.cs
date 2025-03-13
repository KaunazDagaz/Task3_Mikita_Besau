namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var diceList = new List<Dice>();

            if(!DiceParser.TryParse(args, diceList))
            {
                return;
            }

            ProbabilityTable.Initialize(diceList, ProbabilityCalculation.CalculateWinningProbabilities(diceList));

            GameManager gameManager = new GameManager(diceList);
            gameManager.Play();
        }
    }
}