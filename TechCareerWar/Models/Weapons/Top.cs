using TechCareerWar.Models.Ammos;
using TechCareerWar.Models.Weapons.Abstract;

namespace TechCareerWar.Models.Weapons
{
    internal class Top : Ranged<TopAmmo>
    {
        public Top(Top top) : this(top.Brand, top.Model, top.Description, top.Power, top.Magazine.Capacity)
        {

        }

        public Top(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power, magazineCapacity)
        {

        }
    }
}
