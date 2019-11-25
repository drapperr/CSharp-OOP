using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double initialHealthPoints = 100;
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
            this.defenseMode = false;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode => this.defenseMode;

        public void ToggleDefenseMode()
        {
            this.defenseMode = !this.defenseMode;

            if (defenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string mode = "OFF";

            if (defenseMode)
            {
                mode = "ON";
            }

            return base.ToString() + $" *Defense: {mode}";
        }
    }
}
