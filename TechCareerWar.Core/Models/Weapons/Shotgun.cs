using TechCareerWar.Core.Models.Ammos;
using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.Core.Models.Weapons
{
    public class Shotgun : ScopedRanged<ShellAmmo>
    {
        public Shotgun(Shotgun shotgun) : this(shotgun.Brand, shotgun.Model, shotgun.Description, shotgun.Power, shotgun.Magazine.Capacity)
        {

        }

        public Shotgun(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power, magazineCapacity)
        {

        }
    }
}