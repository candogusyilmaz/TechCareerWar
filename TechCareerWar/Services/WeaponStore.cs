using System;
using System.Collections.Generic;
using System.Linq;

using TechCareerWar.Models.Weapons;
using TechCareerWar.Models.Weapons.Abstract;

namespace TechCareerWar.Services
{
    internal class WeaponStore
    {
        private readonly List<Weapon> _weapons;

        public IReadOnlyList<Weapon> Weapons => _weapons;

        /// <summary>
        /// Initializes a new <see cref="WeaponStore"/> with default weapons.
        /// </summary>
        public WeaponStore()
        {
            _weapons = new List<Weapon>()
            {
                new Knife("Rambo","K500","Her kullanımdan sonra bileylenmesi gerekir. Karşı tarafın can değerini 5 azaltır.",5),
                new Knife("Rambo","K700","Her kullanımdan sonra bileylenmesi gerekir. Karşı tarafın can değerini 8 azaltır.",8),
                new Knife("KST","K100","Her kullanımdan sonra bileylenmesi gerekir. Karşı tarafın can değerini 8 azaltır.",8),
                new Pistol("Altıpatlar", "A300","Şarjörü 6 adet çekirdekli mermi alır. Her kullanımda tek mermi atar. Karşı tarafın can değerini 8 azaltır.",8,6),
                new Pistol("Su", "S1000","Şarjörü 6 adet çekirdekli mermi alır. Her kullanımda tek mermi atar. Karşı tarafın can değerini 8 azaltır.",8,6),
                new Shotgun("Poz", "P400","Şarjörü 5 adet saçma mermisi alır. Her kullanımda tek mermi atar. Karşı tarafın can değerini 15 azaltır. Hedefi net görmek için yakınlaştırma imkanı tanır.",15,5),
                new Rifle("Tara", "T600","Şarjörü 50 adet çekirdekli mermi alır. Her kullanımda 5 adet mermi atar. Karşı tarafın can değerini 10 azaltır. Hedefi net görmek için yakınlaştırma imkanı tanır.",2,50,5),
                new RocketLauncher("Rot", "R100","1 adet roket mermisi alır. Her kullanımda tek roket atar. Karşı tarafın can değerini 40 azaltır. Hedefi net görmek için yakınlaştırma imkanı tanır.",40,1),
                new Top("Guny", "G200","1 adet top mermisi alır. Her kullanımda tek top atar. Karşı tarafın can değerini 30 azaltır.",30,1),
            };
        }

        /// <summary>
        /// Gets the weapon from the store.
        /// </summary>
        /// <param name="index">Index of the weapons in the store.</param>
        /// <returns><see cref="Weapon"/></returns>
        /// <exception cref="Exceptions.WeaponsNull"></exception>
        /// <exception cref="Exceptions.WeaponsIndexOutOfReach"></exception>
        public Weapon Buy(int index)
        {
            if (_weapons == null)
                throw new Exception(Exceptions.WeaponsNull);

            Weapon weapon = _weapons.ElementAtOrDefault(index);

            if (weapon == null)
                throw new Exception(Exceptions.WeaponsIndexOutOfReach);

            return DetermineTypeAndReturnNew(weapon);
        }

        /// <summary>
        /// Adds the given weapon to the store.
        /// </summary>
        /// <param name="weapon"></param>
        /// <exception cref="Exceptions.WeaponsNull"></exception>
        /// <exception cref="Exceptions.WeaponsContainsWeapon"></exception>
        public void Add(Weapon weapon)
        {
            if (_weapons == null)
                throw new Exception(Exceptions.WeaponsNull);

            if (_weapons.Contains(weapon))
                throw new Exception(Exceptions.WeaponsContainsWeapon);

            _weapons.Add(weapon);
        }

        /// <summary>
        /// Gets a random weapon from the store
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exceptions.WeaponsNull"></exception>
        /// <exception cref="Exceptions.WeaponsItemCountZero"></exception>
        public Weapon BuyRandom()
        {
            if (_weapons == null)
                throw new Exception(Exceptions.WeaponsNull);

            if (_weapons.Count == 0)
                throw new Exception(Exceptions.WeaponsItemCountZero);

            int index = new Random().Next(0, _weapons.Count);

            Weapon weapon = _weapons.ElementAt(index);

            return DetermineTypeAndReturnNew(weapon);
        }

        private static Weapon DetermineTypeAndReturnNew(Weapon weapon)
        {
            return weapon switch
            {
                Knife => new Knife(weapon as Knife),
                Pistol => new Pistol(weapon as Pistol),
                Rifle => new Rifle(weapon as Rifle),
                Shotgun => new Shotgun(weapon as Shotgun),
                RocketLauncher => new RocketLauncher(weapon as RocketLauncher),
                Top => new Top(weapon as Top),
                _ => null,
            };
        }
    }
}
