using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];
                string teamName = inputArgs[1];

                if (command == "Team")
                {
                    if (!teams.ContainsKey(teamName))
                    {
                        try
                        {
                            teams.Add(teamName, new Team(teamName));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (command == "Add")
                {
                    string playerName = inputArgs[2];
                    int endurance = int.Parse(inputArgs[3]);
                    int sprint = int.Parse(inputArgs[4]);
                    int dribble = int.Parse(inputArgs[5]);
                    int passing = int.Parse(inputArgs[6]);
                    int shooting = int.Parse(inputArgs[7]);

                    if (!teams.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else
                    {
                        try
                        {
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams[teamName].AddPlayer(player);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (command == "Remove")
                {
                    string playerName = inputArgs[2];

                    if (!teams.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else
                    {
                        try
                        {
                            teams[teamName].RemovePlayer(playerName);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (command == "Rating")
                {
                    if (!teams.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else
                    {
                        teams[teamName].PrintRating();
                    }
                }
            }
        }
    }
}
