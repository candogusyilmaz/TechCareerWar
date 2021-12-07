using TechCareerWar.Core.Models.Ammos;
using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.Core.Models.Weapons
{
    public class Top : Ranged<TopAmmo>
    {
        public Top(Top top) : this(top.Brand, top.Model, top.Description, top.Power, top.Magazine.Capacity)
        {

        }

        public Top(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power, magazineCapacity)
        {

        }
    }
}
