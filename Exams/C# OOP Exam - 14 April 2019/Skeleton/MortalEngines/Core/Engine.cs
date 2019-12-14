namespace MortalEngines.Core
{
    using System;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly IMachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');

                string command = input[0];

                try
                {
                    string result = string.Empty;

                    if (command == "Quit")
                    {
                        Environment.Exit(0);
                    }
                    else if (command == "HirePilot")
                    {
                        string name = input[1];

                        result = this.machinesManager.HirePilot(name);
                    }
                    else if (command == "PilotReport")
                    {
                        string name = input[1];

                        result = this.machinesManager.PilotReport(name);
                    }
                    else if (command == "ManufactureTank")
                    {
                        string name = input[1];
                        double attack = double.Parse(input[2]);
                        double defense = double.Parse(input[3]);

                        result = this.machinesManager.ManufactureTank(name, attack, defense);
                    }
                    else if (command == "ManufactureFighter")
                    {
                        string name = input[1];
                        double attack = double.Parse(input[2]);
                        double defense = double.Parse(input[3]);

                        result = this.machinesManager.ManufactureFighter(name, attack, defense);
                    }
                    else if (command == "MachineReport")
                    {
                        string name = input[1];

                        result = this.machinesManager.MachineReport(name);
                    }
                    else if (command == "AggressiveMode")
                    {
                        string name = input[1];

                        result = this.machinesManager.ToggleFighterAggressiveMode(name);
                    }
                    else if (command == "DefenseMode")
                    {
                        string name = input[1];

                        result = this.machinesManager.ToggleTankDefenseMode(name);
                    }
                    else if (command == "Engage")
                    {
                        string pilotName = input[1];
                        string machineName = input[2];

                        result = this.machinesManager.EngageMachine(pilotName, machineName);
                    }
                    else if (command == "Attack")
                    {
                        string attackName = input[1];
                        string defenseName = input[2];

                        result = this.machinesManager.AttackMachines(attackName, defenseName);
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
