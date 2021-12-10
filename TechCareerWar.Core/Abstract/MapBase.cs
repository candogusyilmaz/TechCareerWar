using System;
using System.Collections.Generic;
using System.Linq;

using TechCareerWar.Core.Models.Game;
using TechCareerWar.Core.Services;

namespace TechCareerWar.Core.Abstract
{
    public abstract class MapBase
    {
        public virtual string Name { get; init; }

        public virtual int EnemyCount
        {
            get => _enemies.Count;
            init => _enemies = _enemyStore.CreateEnemies(value);
        }

        public int AliveEnemyCount => _enemies.Count(s => s.IsAlive);

        public int DeadEnemyCount => _enemies.Count(s => !s.IsAlive);

        public IReadOnlyList<Enemy> Enemies => _enemies;

        private readonly EnemyStore _enemyStore;
        private readonly List<Enemy> _enemies;

        public MapBase(string mapName, int enemyCount)
        {
            _enemyStore = new EnemyStore();

            if (enemyCount <= 0)
                throw new ArgumentException(Exceptions.EnemyCountZero);

            Name = mapName;
            EnemyCount = enemyCount;
        }

        public Enemy GetAliveEnemy()
        {
            return _enemies.Find(s => s.IsAlive == true);
        }
    }
}
