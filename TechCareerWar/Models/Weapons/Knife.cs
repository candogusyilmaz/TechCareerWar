using TechCareerWar.Models.Weapons.Abstract;

namespace TechCareerWar.Models.Weapons
{
    internal class Knife : Melee
    {
        public override bool Usable => true;

        private bool _used = false;

        public Knife(Knife knife) : this(knife.Brand, knife.Model, knife.Description, knife.Power)
        {

        }

        public Knife(string brand, string model, string description, int power) : base(brand, model, description, power)
        {

        }

        public override int Use()
        {
            Bileyle();

            _used = true;

            return Power;
        }

        public void Bileyle()
        {
            _used = false;
        }
    }
}
