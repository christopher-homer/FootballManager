namespace FootballManager.Core.Data
{
    public class Team
    {
        public Team(string name, int offensiveRating, int defensiveRating)
        {
            Name = name;
            OffensiveRating = offensiveRating;
            DefensiveRating = defensiveRating;
        }

        public int OffensiveRating { get; private set; }
        public int DefensiveRating { get; private set; }
        public string Name { get; private set; }
    }
}
