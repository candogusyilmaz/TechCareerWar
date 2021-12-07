using TechCareerWar.Models.Ammos;
using TechCareerWar.Models.Weapons.Abstract;

namespace TechCareerWar.Models.Weapons
{
    internal class RocketLauncher : ScopedRanged<RocketAmmo>
    {
        public RocketLauncher(RocketLauncher rl) : this(rl.Brand, rl.Model, rl.Description, rl.Power, rl.Magazine.Capacity)
        {

        }

        public RocketLauncher(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power, magazineCapacity)
        {

        }
    }
}
