using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using ViceCity.Factory;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    using  Contracts;
    
    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private ICollection<IPlayer> civilPlayers;
        private Queue<IGun> guns;
        private IGunFactory _gunFactory;
        private GangNeighbourhood _neighbourhood;

        public Controller()
        {
            mainPlayer = new MainPlayer();
            _gunFactory = new GunFactory();
            guns = new Queue<IGun>();
            civilPlayers = new List<IPlayer>();
            _neighbourhood = new GangNeighbourhood();
        }
        
        public string AddPlayer(string name)
        {
            civilPlayers.Add(new CivilPlayer(name));
            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            try
            {
                    var gun =  _gunFactory.CreateGun(type, name);
                    guns.Enqueue(gun);
                    return $"Successfully added {name} of type: {type}";

            }
            catch (InvalidCastException e)
            {
                return e.Message;
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var gun = guns.Peek();
            
            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(guns.Dequeue());
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            IPlayer player = civilPlayers.FirstOrDefault(x => x.Name == name);
            if (player == null)
            {
                return "Civil player with that name doesn't exists!";
            }
            
            player.GunRepository.Add(guns.Dequeue());
            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string Fight()
        {
            _neighbourhood.Action(mainPlayer,civilPlayers);
            
            if (mainPlayer.LifePoints ==100 && civilPlayers.All(x=>x.LifePoints == 50))
            {
                return "Everything is okay!";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"A fight happened:")
                .AppendLine($"Tommy live points: {mainPlayer.LifePoints}!")
                .AppendLine($"Tommy has killed: {civilPlayers.Count(x => !x.IsAlive)} players!")
                .AppendLine($"Left Civil Players: {civilPlayers.Count(x => x.IsAlive)}!");
            return sb.ToString().TrimEnd();
        }
    }
}