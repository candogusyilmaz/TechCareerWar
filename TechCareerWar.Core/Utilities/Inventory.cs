using System;
using System.Collections.Generic;

using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.Core.Utilities
{
    public class Inventory
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
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public void AddWeapon(Weapon weapon)
        {
            if (_weapons.Count == 3)
                throw new ArgumentException(Exceptions.InventoryMaxItemsReached);

            if (_weapons.Contains(weapon))
                throw new Exception(Exceptions.InventoryAlreadyContainsWeapon);

            _weapons.Add(weapon);
        }
    }
}
