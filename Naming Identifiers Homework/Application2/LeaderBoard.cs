namespace Application2
{
    internal class LeaderBoard
    {
        public LeaderBoard()
        {
        }

        public LeaderBoard(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; set; }

        public int Points { get; set; }
    }
}