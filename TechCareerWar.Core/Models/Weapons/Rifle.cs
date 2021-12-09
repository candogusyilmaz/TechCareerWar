using System;

using TechCareerWar.Core.Models.Ammos;
using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.Core.Models.Weapons
{
    public class Rifle : ScopedRanged<CoreAmmo>
    {
        private readonly int _shootsBulletsAs;

        public Rifle(Rifle rifle) : this(rifle.Brand, rifle.Model, rifle.Description, rifle.Power, rifle.Magazine.Capacity, rifle._shootsBulletsAs)
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
                throw new ArgumentNullException(Exceptions.OutOfBullets);

            Magazine.LoadToChamber(_shootsBulletsAs);

            return Power;
        }
    }
}
