using FootballManager.Core.Data;
using FootballManager.Core.Engines.Match;
using System;
using System.Collections.Generic;

namespace FootballManager.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Team("Aston Villa", 100, 100);
            var t2 = new Team("Birmingham City", 25, 50);

            int t1Wins = 0;
            int t2Wins = 0;
            int draws = 0;

            for (int i = 0; i < 100000; i++)
            {
                MatchResult result = MatchEngine.PlayMatch(t1, t2);

                if (result.Team1Score > result.Team2Score)
                    t1Wins++;
                else if (result.Team1Score < result.Team2Score)
                    t2Wins++;
                else
                    draws++;

                Console.WriteLine($"{t1.Name} {result.Team1Score} : {result.Team2Score} {t2.Name}");

            }

            Console.WriteLine($"T1 Wins %: {Math.Round(t1Wins / 100m, 2)}");
            Console.WriteLine($"T2 Wins %: {Math.Round(t2Wins / 100m, 2)}");
            Console.WriteLine($"Draws %: {Math.Round(draws / 100m, 2)}");


            Console.ReadLine();
        }

        public static List<Team> CreateTeams(int offensivePotentialDiff)
        {
            List<Team> teams = new List<Team>();

            int offensiveRating = 0 + offensivePotentialDiff;
            teams.Add(new Team("Aston Villa", offensiveRating, 0));
            teams.Add(new Team("Birmingham City", offensiveRating, 0));

            return teams;
        }

        public static Team CreateTeam(Random rnd, string name)
        {
            int offensiveRating = rnd.Next(0, 100);
            int defensiveRating = rnd.Next(0, 100);
            return new Team(name, offensiveRating, defensiveRating);
        }
    }
}
