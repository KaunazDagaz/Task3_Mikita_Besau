namespace task3
{
    internal class Dice
    {
        public List<int> values { get; private set; }

        public Dice(IEnumerable<int> values)
        {
            this.values = new List<int>(values);
        }
    }
}
