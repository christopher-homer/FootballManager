using FootballManager.Core.Data;
using FootballManager.Core.Utilities.Generation;
using System.Collections.Generic;

namespace FootballManager.Core.Engines.Match
{
    public class MatchEngine
    {
        public static MatchResult PlayMatch(Team team1, Team team2)
        {
            MatchResult result = new MatchResult();

            int team1OffensivePotential = team1.OffensiveRating - team2.DefensiveRating;
            int team2OffensivePotential = team2.OffensiveRating - team1.DefensiveRating;

            result.Team1Score = WeightedRandomiser<int>.GetValue(GoalWeightings(team1OffensivePotential));
            result.Team2Score = WeightedRandomiser<int>.GetValue(GoalWeightings(team2OffensivePotential));

            return result;
        }

        private static List<WeightedValue<int>> GoalWeightings(int offensivePotential)
        {
            int zeroGoalWeighting = 0;
            int oneGoalWeighting = 0;
            int twoGoalWeighting = 0;
            int threeGoalWeighting = 0;
            int fourGoalWeighting = 0;
            int fiveGoalWeighting = 0;
            int sixGoalWeighting = 0;

            if (offensivePotential < -90)
            {
                zeroGoalWeighting = 95;
                oneGoalWeighting = 4;
                twoGoalWeighting = 1;
            }
            else if (offensivePotential < -80)
            {
                zeroGoalWeighting = 91;
                oneGoalWeighting = 7;
                twoGoalWeighting = 2;
            }
            else if (offensivePotential < -70)
            {
                zeroGoalWeighting = 85;
                oneGoalWeighting = 10;
                twoGoalWeighting = 5;
            }
            else if (offensivePotential < -60)
            {
                zeroGoalWeighting = 75;
                oneGoalWeighting = 15;
                twoGoalWeighting = 10;
            }
            else if (offensivePotential < -50)
            {
                zeroGoalWeighting = 68;
                oneGoalWeighting = 20;
                twoGoalWeighting = 10;
                threeGoalWeighting = 2;
            }
            else if (offensivePotential < -40)
            {
                zeroGoalWeighting = 60;
                oneGoalWeighting = 25;
                twoGoalWeighting = 10;
                threeGoalWeighting = 5;
            }
            else if (offensivePotential < -30)
            {
                zeroGoalWeighting = 50;
                oneGoalWeighting = 38;
                twoGoalWeighting = 10;
                threeGoalWeighting = 2;
            }
            else if (offensivePotential < -20)
            {
                zeroGoalWeighting = 40;
                oneGoalWeighting = 40;
                twoGoalWeighting = 15;
                threeGoalWeighting = 5;
            }
            else if (offensivePotential < -10)
            {
                zeroGoalWeighting = 35;
                oneGoalWeighting = 35;
                twoGoalWeighting = 21;
                threeGoalWeighting = 7;
                fourGoalWeighting = 2;
            }
            else if (offensivePotential < 0)
            {
                zeroGoalWeighting = 30;
                oneGoalWeighting = 35;
                twoGoalWeighting = 25;
                threeGoalWeighting = 8;
                fourGoalWeighting = 2;
            }
            else if (offensivePotential < 10)
            {
                zeroGoalWeighting = 30;
                oneGoalWeighting = 30;
                twoGoalWeighting = 30;
                threeGoalWeighting = 8;
                fourGoalWeighting = 2;
            }
            else if (offensivePotential < 20)
            {
                zeroGoalWeighting = 25;
                oneGoalWeighting = 32;
                twoGoalWeighting = 33;
                threeGoalWeighting = 8;
                fourGoalWeighting = 2;
            }
            else if (offensivePotential < 30)
            {
                zeroGoalWeighting = 22;
                oneGoalWeighting = 30;
                twoGoalWeighting = 25;
                threeGoalWeighting = 23;
            }
            else if (offensivePotential < 40)
            {
                zeroGoalWeighting = 20;
                oneGoalWeighting = 25;
                twoGoalWeighting = 30;
                threeGoalWeighting = 25;
            }
            else if (offensivePotential < 50)
            {
                zeroGoalWeighting = 18;
                oneGoalWeighting = 20;
                twoGoalWeighting = 38;
                threeGoalWeighting = 23;
                fourGoalWeighting = 1;
            }
            else if (offensivePotential < 60)
            {
                zeroGoalWeighting = 15;
                oneGoalWeighting = 20;
                twoGoalWeighting = 37;
                threeGoalWeighting = 26;
                fourGoalWeighting = 2;
            }
            else if (offensivePotential < 70)
            {
                zeroGoalWeighting = 15;
                oneGoalWeighting = 20;
                twoGoalWeighting = 39;
                threeGoalWeighting = 20;
                fourGoalWeighting = 5;
                fiveGoalWeighting = 1;
            }
            else if (offensivePotential < 80)
            {
                zeroGoalWeighting = 10;
                oneGoalWeighting = 20;
                twoGoalWeighting = 35;
                threeGoalWeighting = 25;
                fourGoalWeighting = 8;
                fiveGoalWeighting = 2;
            }
            else if (offensivePotential < 90)
            {
                zeroGoalWeighting = 10;
                oneGoalWeighting = 18;
                twoGoalWeighting = 25;
                threeGoalWeighting = 25;
                fourGoalWeighting = 12;
                fiveGoalWeighting = 8;
                sixGoalWeighting = 2;
            }
            else if (offensivePotential <= 100)
            {
                zeroGoalWeighting = 10;
                oneGoalWeighting = 15;
                twoGoalWeighting = 20;
                threeGoalWeighting = 25;
                fourGoalWeighting = 15;
                fiveGoalWeighting = 10;
                sixGoalWeighting = 5;
            }

            List<WeightedValue<int>> weightings = new List<WeightedValue<int>>();

            weightings.Add(new WeightedValue<int>(0, zeroGoalWeighting));
            weightings.Add(new WeightedValue<int>(1, oneGoalWeighting));
            weightings.Add(new WeightedValue<int>(2, twoGoalWeighting));
            weightings.Add(new WeightedValue<int>(3, threeGoalWeighting));
            weightings.Add(new WeightedValue<int>(4, fourGoalWeighting));
            weightings.Add(new WeightedValue<int>(5, fiveGoalWeighting));
            weightings.Add(new WeightedValue<int>(6, sixGoalWeighting));
            return weightings;
        }
    }
}
