namespace ViceCity.Models.Guns
{
    public class Pistol :Gun
    {
        private const int PistolBulletsPerBarrel = 10;
        private const int PistolTotalBullets = 100;
        public Pistol(string name) : base(name, PistolBulletsPerBarrel, PistolTotalBullets)
        {
            this.BulletsPerShot = 1;
        }
    }
}