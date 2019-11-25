using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private readonly List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines=new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine==null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            machines.Add(machine);
        }

        public string Report()
        {
            var sb=new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (IMachine machine in machines)
            {
                sb.AppendLine($"- {machine.Name}");
                sb.AppendLine($" *Type: {machine.GetType().Name}");
                sb.AppendLine($" *Health: {machine.HealthPoints:F2}");
                sb.AppendLine($" *Attack: {machine.AttackPoints:F2}");
                sb.AppendLine($" *Defense: {machine.DefensePoints:F2}");
                sb.AppendLine($" *Targets: {machine.Targets.Count}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
