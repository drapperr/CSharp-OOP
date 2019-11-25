using System;
using System.Collections.Generic;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private Dictionary<string, IPilot> pilots;
        private Dictionary<string, IMachine> machines;

        public MachinesManager()
        {
            pilots = new Dictionary<string, IPilot>();
            machines = new Dictionary<string, IMachine>();
        }

        public string HirePilot(string name)
        {
            if (pilots.ContainsKey(name))
            {
                return $"Pilot {name} is hired already";
            }
            else
            {
                pilots.Add(name, new Pilot(name));
                return $"Pilot {name} hired";
            }
        }

        public string PilotReport(string pilotReporting)
        {
            if (!pilots.ContainsKey(pilotReporting))
            {
                return $"Pilot {pilotReporting} could not be found";
            }

            return pilots[pilotReporting].Report();
        }

        public string MachineReport(string machineName)
        {
            if (!machines.ContainsKey(machineName))
            {
                return $"Machine {machineName} could not be found";
            }

            return machines[machineName].ToString();
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.ContainsKey(name))
            {
                return $"Machine {name} is manufactured already";
            }
            Tank tank=new Tank(name, attackPoints, defensePoints);
            machines.Add(name,tank);

            return $"Tank {name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
        }
        public string ToggleTankDefenseMode(string tankName)
        {
            if (!machines.ContainsKey(tankName))
            {
                return $"Machine {tankName} could not be found";
            }

            if (machines[tankName] is Tank)
            {
                (machines[tankName] as Tank)?.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }

            return $"Machine {tankName} could not be found";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.ContainsKey(name))
            {
                return $"Machine {name} is manufactured already";
            }
            Fighter fighter=new Fighter(name, attackPoints, defensePoints);
            machines.Add(name,fighter);

            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!machines.ContainsKey(fighterName))
            {
                return $"Machine {fighterName} could not be found";
            }

            if (machines[fighterName] is Fighter)
            {
                (machines[fighterName] as Fighter)?.ToggleAggressiveMode();         //??????
                return $"Fighter {fighterName} toggled aggressive mode";
            }

            return $"Machine {fighterName} could not be found";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!pilots.ContainsKey(selectedPilotName))
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (!machines.ContainsKey(selectedMachineName))
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machines[selectedMachineName].Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            machines[selectedMachineName].Pilot = pilots[selectedPilotName];

            pilots[selectedPilotName].AddMachine(machines[selectedMachineName]);

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!machines.ContainsKey(attackingMachineName))
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            if (!machines.ContainsKey(defendingMachineName))
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (machines[defendingMachineName].HealthPoints == 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            if (machines[attackingMachineName].HealthPoints==0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            
            double attackPoints = machines[attackingMachineName].AttackPoints;

            attackPoints -= machines[defendingMachineName].DefensePoints;

            if (attackPoints > 0)
            {
                machines[defendingMachineName].HealthPoints -= attackPoints;
            }
            else
            {
                attackPoints = 0;
            }

            if (machines[defendingMachineName].HealthPoints <= 0)
            {
                machines[defendingMachineName].HealthPoints = 0;
            }

            if (!machines[attackingMachineName].Targets.Contains(machines[defendingMachineName].Name))
            {
                machines[attackingMachineName].Targets.Add(machines[defendingMachineName].Name);
            }
           
            return
                $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {machines[defendingMachineName].HealthPoints:F2}";
        }
    }
}