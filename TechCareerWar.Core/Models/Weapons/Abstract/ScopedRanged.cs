namespace TechCareerWar.Core.Models.Weapons.Abstract
{
    public abstract class ScopedRanged<AmmoType> : Ranged<AmmoType> where AmmoType : new()
    {
        protected ScopedRanged(string brand, string model, string description, int power, int magazineCapacity) : base(brand, model, description, power, magazineCapacity)
        {
        }

        public virtual void ZoomIn()
        {

        }

        public virtual void ZoomOut()
        {

        }
    }
}
