using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core.Contracts
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;

        public Engine()
        {
            this.championshipController=new ChampionshipController();
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
                    if (command=="End")
                    {
                        Environment.Exit(0);
                    }
                    else if (command == "CreateRider")
                    {
                        string name = input[1];

                        result = this.championshipController.CreateRider(name);
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        string type = input[1];
                        string name = input[2];
                        int hp = int.Parse(input[3]);

                        result = this.championshipController.CreateMotorcycle(type,name,hp);
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        string riderName = input[1];
                        string motorcycleName = input[2];

                        result = this.championshipController.AddMotorcycleToRider(riderName,motorcycleName);
                    }
                    else if (command == "AddRiderToRace")
                    {
                        string raceName = input[1];
                        string riderName = input[2];

                        result = this.championshipController.AddRiderToRace(raceName, riderName);
                    }
                    else if (command == "CreateRace")
                    {
                        string name = input[1];
                        int laps = int.Parse(input[2]);

                        result = this.championshipController.CreateRace(name, laps);
                    }
                    else if (command == "StartRace")
                    {
                        string name = input[1];

                        result = this.championshipController.StartRace(name);
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
