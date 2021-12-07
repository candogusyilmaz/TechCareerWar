using TechCareerWar.Core.Models.Ammos;
using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.Core.Models.Weapons
{
    public class Pistol : Ranged<CoreAmmo>
    {
        public Pistol(Pistol pistol) : this(pistol.Brand, pistol.Model, pistol.Description, pistol.Power, pistol.Magazine.Capacity)
        {

        }

        public Pistol(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power, magazineCapacity)
        {
        }
    }
}
