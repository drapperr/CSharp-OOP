namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int PistolShoot = 1;

        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (!CanFire)
            {
                return 0;
            }

            if (this.BulletsPerBarrel==0)
            {
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
            }

            this.BulletsPerBarrel -= PistolShoot;
            return PistolShoot;
        }
    }
}
