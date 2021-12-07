using System;

using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.Core.Models.Weapons
{
    public class Knife : Melee, IHoneable
    {
        public override bool Usable => IsHoned;

        public bool IsHoned { get; private set; }

        public Knife(Knife knife) : this(knife.Brand, knife.Model, knife.Description, knife.Power)
        {

        }

        public Knife(string brand, string model, string description, int power) : base(brand, model, description, power)
        {

        }

        public override int Use()
        {
            if (IsHoned == false)
                throw new Exception(Exceptions.KnifeNotHoned);

            IsHoned = false;

            return Power;
        }

        public void Hone()
        {
            IsHoned = true;
        }
    }
}
