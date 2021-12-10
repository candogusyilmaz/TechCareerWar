using System;

using TechCareerWar.Core.Models.Ammos.Abstract;
using TechCareerWar.Core.Utilities;

namespace TechCareerWar.Core.Models.Weapons.Abstract
{
    public abstract class Ranged<AmmoType> : Weapon where AmmoType : IAmmo, new()
    {
        public Magazine<AmmoType> Magazine { get; init; }

        public override bool Usable => Magazine.AmmoCount > 0;

        public Ranged(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power)
        {
            Magazine = new Magazine<AmmoType>(magazineCapacity);
        }

        public override int Use()
        {
            if (Usable is false)
                throw new Exception(Exceptions.OutOfBullets);

            Magazine.LoadToChamber(1);

            return Power;
        }
    }
}
