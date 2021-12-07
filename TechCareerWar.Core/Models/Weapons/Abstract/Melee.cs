namespace TechCareerWar.Core.Models.Weapons.Abstract
{
    public abstract class Melee : Weapon
    {
        protected Melee(string brand, string model, string description, int power) : base(brand, model, description, power)
        {

        }
    }
}
