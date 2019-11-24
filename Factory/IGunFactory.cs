using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Factory
{
    public interface IGunFactory
    {
        IGun CreateGun(string type, string name);
    }
}