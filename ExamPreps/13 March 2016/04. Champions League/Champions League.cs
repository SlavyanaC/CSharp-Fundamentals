using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Champions_League
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamsWithOpponents = new Dictionary<string, List<string>>();
            var teamsWithWins = new Dictionary<string, int>();
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "stop")
            {
                var tokens = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                var firstTeam = tokens[0];
                var secondTeam = tokens[1];
                var homeResult = tokens[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var firstHome = homeResult[0];
                var secondHome = homeResult[1];
                var awayResult = tokens[3].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var firstAway = awayResult[1];
                var seconAway = awayResult[0];

                string winner = DetermineWinner(firstTeam, secondTeam, firstHome, secondHome, firstAway, seconAway);
                if (!teamsWithOpponents.ContainsKey(firstTeam) && !teamsWithOpponents.ContainsKey(secondTeam)) // Both are non existing in the dictionary
                {
                    teamsWithOpponents.Add(firstTeam, new List<string>());
                    teamsWithOpponents[firstTeam].Add(secondTeam);

                    teamsWithOpponents.Add(secondTeam, new List<string>());
                    teamsWithOpponents[secondTeam].Add(firstTeam);

                    teamsWithWins.Add(firstTeam, 0);
                    teamsWithWins.Add(secondTeam, 0);
                    if (winner == firstTeam)
                    {
                        teamsWithWins[firstTeam]++;
                    }
                    else
                    {
                        teamsWithWins[secondTeam]++;
                    }
                }
                else if (!teamsWithOpponents.ContainsKey(firstTeam) && teamsWithOpponents.ContainsKey(secondTeam)) // only the FIRST is non existing in the dictionary
                {
                    teamsWithOpponents.Add(firstTeam, new List<string>());
                    teamsWithOpponents[firstTeam].Add(secondTeam);
                    teamsWithOpponents[secondTeam].Add(firstTeam);

                    if (winner == firstTeam)
                    {
                        if (!teamsWithWins.ContainsKey(firstTeam))
                        {
                            teamsWithWins.Add(firstTeam, 0);
                        }
                        teamsWithWins[firstTeam]++;
                    }
                    else
                    {
                        if (!teamsWithWins.ContainsKey(firstTeam))
                        {
                            teamsWithWins.Add(firstTeam, 0);
                        }
                        teamsWithWins[secondTeam]++;
                    }
                }

                else if (!teamsWithOpponents.ContainsKey(secondTeam) && teamsWithOpponents.ContainsKey(firstTeam)) // only the SECOND is non existing in the dictionary
                {
                    teamsWithOpponents.Add(secondTeam, new List<string>());
                    teamsWithOpponents[secondTeam].Add(firstTeam);
                    teamsWithOpponents[firstTeam].Add(secondTeam);

                    if (winner == firstTeam)
                    {
                        if (!teamsWithWins.ContainsKey(secondTeam))
                        {
                            teamsWithWins.Add(secondTeam, 0);
                        }
                        teamsWithWins[firstTeam]++;
                    }
                    else
                    {
                        if (!teamsWithOpponents.ContainsKey(secondTeam))
                        {
                            teamsWithWins.Add(secondTeam, 0);
                        }
                        teamsWithWins[secondTeam]++;
                    }
                }

                else // Both team are existing
                {
                    teamsWithOpponents[firstTeam].Add(secondTeam);
                    teamsWithOpponents[secondTeam].Add(firstTeam);
                    if (winner == firstTeam)
                    {
                        teamsWithWins[firstTeam]++;
                    }
                    else
                    {
                        teamsWithWins[secondTeam]++;
                    }
                }
            }

            foreach (var kvpWins in teamsWithWins.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine(kvpWins.Key);
                Console.WriteLine($"- Wins: {kvpWins.Value}");
                Console.WriteLine("- Opponents: " + string.Join(", ", teamsWithOpponents[kvpWins.Key].OrderBy(o => o)));
            }
        }

        private static string DetermineWinner(string firstTeam, string secondTeam, int firstHome, int secondHome, int firstAway, int seconAway)
        {
            string winner = string.Empty;
            int firstTotal = firstHome + firstAway;
            int secondTotal = secondHome + seconAway;
            if (firstTotal > secondTotal)
            {
                winner = firstTeam;
            }
            else if (firstTotal < secondTotal)
            {
                winner = secondTeam;
            }
            else
            {
                winner = DetermineBetterAwayResult(firstTeam, secondTeam, firstHome, secondHome, firstAway, seconAway);
            }

            return winner;
        }

        private static string DetermineBetterAwayResult(string firstTeam, string secondTeam, int firstHome, int secondHome, int firstAway, int seconAway)
        {
            var winner = string.Empty;
            double firstTotal = 0;
            double secondTotal = 0;
            for (int i = 0; i < firstHome; i++)
            {
                firstTotal++;
            }
            for (int i = 0; i < firstAway; i++)
            {
                firstTotal += 1.5;
            }
            for (int i = 0; i < seconAway; i++)
            {
                secondTotal++;
            }
            for (int i = 0; i < secondHome; i++)
            {
                secondTotal += 1.5;
            }

            if (firstTotal > secondTotal)
            {
                winner = firstTeam;
            }
            else if (firstTotal < secondTotal)
            {
                winner = secondTeam;
            }

            return winner;
        }
    }
}
