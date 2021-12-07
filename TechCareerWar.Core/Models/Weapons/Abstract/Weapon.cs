namespace TechCareerWar.Core.Models.Weapons.Abstract
{
    public abstract class Weapon
    {
        public string Brand { get; init; }
        public string Model { get; init; }
        public string Description { get; init; }
        public int Power { get; init; }
        public abstract bool Usable { get; }

        public Weapon(string brand, string model, string description, int power)
        {
            Brand = brand;
            Model = model;
            Description = description;
            Power = power;
        }

        /// <summary>
        /// Uses the weapon and returns the damage output.
        /// </summary>
        /// <returns>Damage output as <see cref="int"/>.</returns>
        public abstract int Use();
    }
}
