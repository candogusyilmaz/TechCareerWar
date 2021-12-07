using System;

using TechCareerWar.Core.Abstract;

namespace TechCareerWar.Core
{
    public class Map : MapBase
    {
        public override string Name
        {
            get => base.Name;
            init
            {
                if (value.Length > 15)
                    throw new ArgumentException(Exceptions.MapNameTooLong);

                base.Name = value;
            }
        }

        public override int EnemyCount
        {
            get => base.EnemyCount;
            init
            {
                if ((3 <= value && value <= 8) == false)
                    throw new ArgumentException(Exceptions.FaultyEnemyCount);

                base.EnemyCount = value;
            }
        }

        public Map(string mapName, int enemyCount) : base(mapName, enemyCount)
        {

        }
    }
}
