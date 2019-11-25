using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine,IFighter
    {
        private const double initialHealthPoints = 200;
        private bool aggressiveMode;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
            this.aggressiveMode = false;   
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode => this.aggressiveMode;

        public void ToggleAggressiveMode()
        {
            this.aggressiveMode = !this.aggressiveMode;

            if (aggressiveMode)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string mode = "OFF";
            if (aggressiveMode)
            {
                mode = "ON";
            }
            return base.ToString() + $" *Aggressive: {mode}";
        }
    }
}
