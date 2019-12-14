namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly IManagerController managerController;

        public Engine()
        {
            this.managerController = new ManagerController();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];

                string result = string.Empty;

                try
                {
                    if (command== "Exit")
                    {
                        Environment.Exit(0);
                    }
                    else if (command== "AddPlayer")
                    {
                        string type = input[1];
                        string name = input[2];

                        result = this.managerController.AddPlayer(type, name);
                    }
                    else if (command == "AddCard")
                    {
                        string type = input[1];
                        string name = input[2];

                        result = this.managerController.AddCard(type, name);
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string userName = input[1];
                        string cardName = input[2];

                        result = this.managerController.AddPlayerCard(userName, cardName);
                    }
                    else if (command == "Fight")
                    {
                        string attackUser = input[1];
                        string enemyUser = input[2];

                        result = this.managerController.Fight(attackUser, enemyUser);
                    }
                    else if (command == "Report")
                    {
                        result = this.managerController.Report();
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
