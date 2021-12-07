using System;

using TechCareerWar.Models.Ammos;
using TechCareerWar.Models.Weapons.Abstract;

namespace TechCareerWar.Models.Weapons
{
    internal class Rifle : ScopedRanged<CoreAmmo>
    {
        private readonly int _shootsBulletsAs;

        public Rifle(Rifle rifle) : this(rifle.Brand, rifle.Model, rifle.Description, rifle.Power, rifle.Magazine.Capacity)
        {

        }

        public Rifle(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power, magazineCapacity)
        {
            _shootsBulletsAs = 1;
        }

        public Rifle(string brand, string model, string description, int power, int magazineCapacity, int shootsBulletsAs) : this(brand, model, description, power, magazineCapacity)
        {
            _shootsBulletsAs = shootsBulletsAs;
        }

        public override int Use()
        {
            if (Usable is false)
                throw new Exception("no bullet");

            Magazine.LoadToChamber(_shootsBulletsAs);

            return Power;
        }
    }
}
