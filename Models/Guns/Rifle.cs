namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int RifleBarrelCapacity = 50;
        private const int RifleTotalBullets = 500;

        public Rifle(string name) : base(name, RifleBarrelCapacity, RifleTotalBullets)
        {
            this.BulletsPerShot = 5;
        }
    }
}