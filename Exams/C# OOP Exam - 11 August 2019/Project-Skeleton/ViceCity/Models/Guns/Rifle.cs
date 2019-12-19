namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int RifleShoot = 5;

        public Rifle(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (!CanFire)
            {
                return 0;
            }

            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
            }

            this.BulletsPerBarrel -= RifleShoot;
            return RifleShoot;
        }
    }
}
