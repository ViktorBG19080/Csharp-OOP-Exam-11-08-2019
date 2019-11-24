using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    using  Contracts;
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            MainPlayerAction(mainPlayer, civilPlayers);

            CivilPlayersAction(mainPlayer, civilPlayers);
        }

        private void CivilPlayersAction(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            var target = mainPlayer;
            foreach (var attacker in civilPlayers.Where(x=>x.IsAlive))
            {
                GunFight(attacker, target);
                if (!target.IsAlive)
                {
                    break;
                }
            }
        }

        private void MainPlayerAction(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            for (int i = 0; i < civilPlayers.Count; i++)
            {
                var target = civilPlayers.ElementAt(i);
                GunFight(mainPlayer, target);

                if (!AttackerHasWeapons(mainPlayer))
                    break;
            }
        }

        private void GunFight(IPlayer attacker, IPlayer target)
        {
           
            while (AttackerHasWeapons(attacker) && target.IsAlive)
            {
                var currentWeapon = attacker.GunRepository.Models.ElementAt(0);
                
                if (currentWeapon.CanFire)
                {
                    target.TakeLifePoints(currentWeapon.Fire());
                }
                else
                {
                    attacker.GunRepository.Remove(currentWeapon);
                }
            }
        }

        private bool AttackerHasWeapons(IPlayer player)
        {
            return player.GunRepository.Models.Count > 0;
        }
    }
}