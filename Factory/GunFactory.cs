using System;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Factory
{
    public class GunFactory : IGunFactory
    {
        public IGun CreateGun(string type, string name)
        {
            IGun result = null;
            switch (type)
            {
                case "Pistol":result = new Pistol(name);
                    break;
                case "Rifle": result = new Rifle(name);
                    break;
                default: 
                    throw new InvalidOperationException("Invalid gun type!");
            }

            return result;
        }
    }
}