namespace task3
{
    internal interface ISelectionTable
    {
        int DisplayFirstMoveSelectionMenu();
        int DisplayDiceSelectionMenu(string[] diceConfigurations);
        int DisplayNumberSelectionMenu(int modulo);
    }
}
