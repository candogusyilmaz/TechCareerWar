using TechCareerWar.Models.Ammos;
using TechCareerWar.Models.Weapons.Abstract;

namespace TechCareerWar.Models.Weapons
{
    internal class Shotgun : ScopedRanged<ShellAmmo>
    {
        public Shotgun(Shotgun shotgun) : this(shotgun.Brand, shotgun.Model, shotgun.Description, shotgun.Power, shotgun.Magazine.Capacity)
        {

        }

        public Shotgun(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power, magazineCapacity)
        {

        }
    }
}