using System;

namespace PlayersAndMonsters.Core.Contracts
{
    public class Engine : IEngine
    {
        public void Run()
        {
            ManagerController managerController = new ManagerController();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                try
                {
                    if (command == "AddPlayer")
                    {
                        string type = input[1];
                        string name = input[2];

                        string result = managerController.AddPlayer(type, name);
                        Console.WriteLine(result);
                    }
                    else if (command == "AddCard")
                    {
                        string type = input[1];
                        string name = input[2];

                        string result = managerController.AddCard(type, name);
                        Console.WriteLine(result);
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string userName = input[1];
                        string cardName = input[2];

                        string result = managerController.AddPlayerCard(userName, cardName);
                        Console.WriteLine(result);
                    }
                    else if (command == "Fight")
                    {
                        string attacker = input[1];
                        string enemy = input[2];

                        string result = managerController.Fight(attacker, enemy);
                        Console.WriteLine(result);
                    }
                    else if (command == "Report")
                    {
                        string result = managerController.Report();
                        Console.WriteLine(result);
                    }
                    else if (command == "Exit")
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
