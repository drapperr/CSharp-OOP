using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Core.Contracts;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private IMachinesManager machinesManager;

        public Engine()
        {
            machinesManager = new MachinesManager();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] inputArgs = input.Split(" ");
                string command = inputArgs[0];

                try
                {
                    string result = string.Empty;

                    switch (command)
                    {
                        case "HirePilot":
                            result = machinesManager.HirePilot(inputArgs[1]);
                            break;

                        case "PilotReport":
                            result = machinesManager.PilotReport(inputArgs[1]);
                            break;

                        case "ManufactureTank":
                            result = machinesManager.ManufactureTank(inputArgs[1],
                                double.Parse(inputArgs[2]),
                                double.Parse(inputArgs[3]));
                            break;

                        case "ManufactureFighter":
                            result = machinesManager.ManufactureFighter(inputArgs[1],
                                double.Parse(inputArgs[2]),
                                double.Parse(inputArgs[3]));
                            break;

                        case "MachineReport":
                            result = machinesManager.MachineReport(inputArgs[1]);
                            break;

                        case "AggressiveMode":
                            result = machinesManager.ToggleFighterAggressiveMode(inputArgs[1]);
                            break;

                        case "DefenseMode":
                            result = machinesManager.ToggleTankDefenseMode(inputArgs[1]);
                            break;

                        case "Engage":
                            result = machinesManager.EngageMachine(inputArgs[1],
                                inputArgs[2]);
                            break;

                        case "Attack":
                            result=machinesManager.AttackMachines(inputArgs[1],
                                inputArgs[2]);
                            break;

                        case "Quit":
                            Environment.Exit(0);
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error:" + e.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}
