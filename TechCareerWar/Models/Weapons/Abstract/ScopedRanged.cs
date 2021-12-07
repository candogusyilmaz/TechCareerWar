namespace TechCareerWar.Models.Weapons.Abstract
{
    internal abstract class ScopedRanged<AmmoType> : Ranged<AmmoType> where AmmoType : new()
    {
        protected ScopedRanged(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power, magazineCapacity)
        {
        }

        public void ZoomIn()
        {

        }

        public void ZoomOut()
        {

        }
    }
}
