namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string MainPlayerName = "Tommy Vercetti";
        private const int MainPlayerLifePoints = 100;
        
        public MainPlayer():base(MainPlayerName,MainPlayerLifePoints)
        {
            
        }
    }
}