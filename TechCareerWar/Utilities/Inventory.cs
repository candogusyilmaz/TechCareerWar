using System;
using System.Collections.Generic;

using TechCareerWar.Models.Weapons.Abstract;

namespace TechCareerWar.Utilities
{
    internal class Inventory
    {
        /// <summary>
        /// Returns 'true' if <see cref="Inventory"/> has any usable weapons else returns 'false'.
        /// </summary>
        public bool HasUsableWeapon => _weapons.Find(s => s.Usable == true) != null;

        public IReadOnlyList<Weapon> Weapons => _weapons;

        private readonly List<Weapon> _weapons;

        /// <summary>
        /// Initializes a new empty <see cref="Inventory"/>.
        /// </summary>
        public Inventory()
        {
            _weapons = new List<Weapon>();
        }

        /// <summary>
        /// Adds weapon to the <see cref="Inventory"/>.
        /// </summary>
        /// <exception cref="Exceptions.InventoryMaxItemsReached"></exception>
        /// <exception cref="Exceptions.InventoryAlreadyContainsWeapon"></exception>
        public void AddWeapon(Weapon weapon)
        {
            if (_weapons.Count == 3)
                throw new Exception(Exceptions.InventoryMaxItemsReached);

            if (_weapons.Contains(weapon))
                throw new Exception(Exceptions.InventoryAlreadyContainsWeapon);

            _weapons.Add(weapon);
        }
    }
}
