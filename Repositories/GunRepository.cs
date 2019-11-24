using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Repositories
{
    using  Contracts;
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> weapons;

        public GunRepository()
        {
            this.weapons = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => weapons;
        public void Add(IGun model)
        {
            weapons.Add(model);
        }

        public bool Remove(IGun model)
        {
            var result = false;
            var gun = Find(model.Name);
            
            if (gun != null)
            {
                weapons.Remove(gun);
                result = true;
            }

            return result;
        }

        public IGun Find(string name)
        {
            return weapons.FirstOrDefault(x => x.Name == name);
        }
    }
}