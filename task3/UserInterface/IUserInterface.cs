namespace task3
{
    internal interface IUserInterface
    {
        bool GetFirstMoveDecision(CryptoRandomGenerator cryptoRandomGenerator);
        Dice GetUserSelectedDice(List<Dice> diceList);
        Dice GetComputerSelectedDice(List<Dice> diceList, CryptoRandomGenerator cryptoRandomGenerator);
        int GetDiceThrowResult(Dice dice, CryptoRandomGenerator cryptoRandomGenerator);
        void ShowWinner(int userResult, int computerResult);
    }
}
