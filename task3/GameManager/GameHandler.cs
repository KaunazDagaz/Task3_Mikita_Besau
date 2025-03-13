namespace task3
{
    internal class GameHandler
    {
        private readonly IUserInterface userInterface;

        public GameHandler(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        public bool DetermineFirstMove()
        {
            var cryptoRandomGenerator = new CryptoRandomGenerator(0, 2);
            return userInterface.GetFirstMoveDecision(cryptoRandomGenerator);
        }

        public Dice UserSelectDice(List<Dice> diceList)
        {
            return userInterface.GetUserSelectedDice(diceList);
        }

        public Dice ComputerSelectDice(List<Dice> diceList)
        {
            var cryptoRandomGenerator = new CryptoRandomGenerator(0, diceList.Count);
            return userInterface.GetComputerSelectedDice(diceList, cryptoRandomGenerator);
        }

        public int PerformThrow(Dice dice)
        {
            var cryptoRandomGenerator = new CryptoRandomGenerator(0, 6);
            return userInterface.GetDiceThrowResult(dice, cryptoRandomGenerator);
        }

        public void DisplayWinner(int userResult, int computerResult)
        {
            userInterface.ShowWinner(userResult, computerResult);
        }
    }
}
