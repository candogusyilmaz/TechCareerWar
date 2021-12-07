using System;

using TechCareerWar.Utilities;

namespace TechCareerWar.Models.Weapons.Abstract
{
    internal abstract class Ranged<AmmoType> : Weapon where AmmoType : new()
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
                throw new Exception("no bullet");

            Magazine.LoadToChamber(1);

            return Power;
        }
    }
}
