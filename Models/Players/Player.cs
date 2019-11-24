using System;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    using  Contracts;
    
    public abstract class Player : IPlayer
    {
        private string _name;
        private int _lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }
        
        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }

                this._name = value;
            }
        }

        public int LifePoints
        {
            get=>this._lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException( "Player life points cannot be below zero!");
                }

                this._lifePoints = value;
            }
        }
        
        public bool IsAlive => this.LifePoints > 0;
        public IRepository<IGun> GunRepository { get; private set; }

        public virtual void TakeLifePoints(int points)
        {
            LifePoints = LifePoints - points <= 0 ? 0 : LifePoints - points;
        }
    }
}