namespace TechCareerWar.Models.Weapons.Abstract
{
    internal abstract class Melee : Weapon
    {
        protected Melee(string brand, string model, string description, int power) : base(brand, model, description, power)
        {

        }
    }
}
