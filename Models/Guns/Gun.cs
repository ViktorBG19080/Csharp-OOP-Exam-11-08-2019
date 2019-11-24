using System;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string _name;
        private int _bulletsPerBarrel;
        private int _totalBullets;
        
        

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }
        
        public string Name
        {
            get=>_name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException("Name cannot be null or a white space!");
                }

                _name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get=> _bulletsPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }

                _bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get=>_totalBullets;
            protected 
            set
            {
                if (value < 0)
                {
                    throw new AggregateException("Total bullets cannot be below zero!");
                }

                _totalBullets = value;
            }
        }

        public bool CanFire => TotalBullets+BulletsInBarrel >= BulletsPerShot;

        protected int BulletsPerShot { get; set; }
        protected int BulletsInBarrel { get; set; }

        public virtual int Fire()
        {
            if (BulletsInBarrel == 0)
            {
                Reload();    
            }

            BulletsInBarrel -= BulletsPerShot;
            return BulletsPerShot;
        }

        private void Reload()
        {
            BulletsInBarrel = TotalBullets < BulletsPerBarrel ? TotalBullets : BulletsPerBarrel;
            TotalBullets -= BulletsInBarrel;
        }
    }
}