using System;
using System.Collections.Generic;

using TechCareerWar.Core.Models.Game;
using TechCareerWar.Core.Models.Game.Abstract;
using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.Core.Services
{
    public class EnemyStore
    {
        private readonly WeaponStore _weaponStore;

        /// <summary>
        /// Initializes a new empty <see cref="EnemyStore"/>.
        /// </summary>
        public EnemyStore()
        {
            _weaponStore = new WeaponStore();
        }

        /// <summary>
        /// Creates and returns enemies based on <paramref name="min"/> and <paramref name="max"/> (both included) values.
        /// </summary>
        /// <param name="min">Minimum number of enemies</param>
        /// <param name="max">Maximum number of enemies</param>
        /// <returns>List of <see cref="Enemy"/>.</returns>
        public List<Enemy> CreateEnemies(int min, int max)
        {
            int randomEnemyCount = new Random().Next(min, max + 1);

            return CreateEnemies(randomEnemyCount);
        }

        /// <summary>
        /// Creates and returns enemies based on <paramref name="count"/>.
        /// </summary>
        /// <param name="count">Number of enemies</param>
        /// <returns>List <see cref="Enemy"/>.</returns>
        public List<Enemy> CreateEnemies(int count)
        {
            List<Enemy> enemyList = new();
            Weapon randomWeapon;
            int randomHP;

            for (int i = 0; i < count; i++)
            {
                randomWeapon = _weaponStore.BuyRandom();
                randomHP = new Random().Next(30, 71);
                enemyList.Add(new Enemy(randomHP, randomWeapon));
            }

            return enemyList;
        }
    }
}
