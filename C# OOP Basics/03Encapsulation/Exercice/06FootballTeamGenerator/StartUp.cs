using System;
using System.Collections.Generic;
using System.Linq;

namespace _06FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(';');
                try
                {
                    switch (tokens[0])
                    {
                        case "Team":
                            teams.Add(new Team(tokens[1]));
                            break;
                        case "Add":
                            if (!teams.Any(t => t.Name == tokens[1]))
                            {
                                throw new ArgumentException($"Team {tokens[1]} does not exist.");
                            }
                            else
                            {
                                Team currentTeam = teams.FirstOrDefault(t => t.Name == tokens[1]);
                                Player newPlayer = new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
                                currentTeam.AddPlayer(newPlayer);
                            }
                            break;
                        case "Remove":
                            Team teamToDeletePlayer = teams.FirstOrDefault(t => t.Name == tokens[1]);
                            teamToDeletePlayer.RemovePlayer(tokens[2]);
                            break;
                        case "Rating":
                            if (!teams.Any(t => t.Name == tokens[1]))
                            {
                                throw new ArgumentException($"Team {tokens[1]} does not exist.");
                            }
                            else
                            {
                                Team wantedTeam = teams.FirstOrDefault(t => t.Name == tokens[1]);
                                Console.WriteLine(wantedTeam.ToString());
                            }
                            break;
                    }
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
        }
    }
}
