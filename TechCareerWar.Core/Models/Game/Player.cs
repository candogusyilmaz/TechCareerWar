using System;

using TechCareerWar.Core.Delegates;
using TechCareerWar.Core.Models.Game.Abstract;
using TechCareerWar.Core.Models.Weapons.Abstract;
using TechCareerWar.Core.Utilities;

namespace TechCareerWar.Core.Models.Game
{
    public class Player : Mortal, IAttackable
    {
        public event OnAttackHandler OnAttack;

        public string Name { get; init; }
        public Inventory Inventory { get; init; }
        public Weapon EquippedWeapon { get; private set; }

        public Player(string name) : base(100)
        {
            Name = name;
            Inventory = new Inventory();
        }

        /// <summary>
        /// Attacks with the weapon.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        protected override void Action()
        {
            if (Inventory.HasUsableWeapon == false)
                throw new ArgumentException(Exceptions.InventoryHasNoUsableWeapons);

            if (EquippedWeapon == null)
                throw new ArgumentNullException(Exceptions.AttackingWithoutEquippedWeapon);

            OnAttack?.Invoke(EquippedWeapon.Use());
        }

        /// <summary>
        /// Change the equipped weapon from the inventory.
        /// </summary>
        /// <param name="index">Index of the weapon in the inventory.</param>
        public void ChangeEquippedWeapon(int index)
        {
            EquippedWeapon = Inventory.Weapons[index];
        }
    }
}
