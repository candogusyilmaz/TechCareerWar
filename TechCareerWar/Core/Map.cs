using System;

using TechCareerWar.Core.Abstract;

namespace TechCareerWar.Core
{
    internal class Map : MapBase
    {
        public override string Name
        {
            get => base.Name;
            init
            {
                if (value.Length > 15)
                    throw new Exception("Harita ismi 15 karakterden fazla olamaz.");

                base.Name = value;
            }
        }

        public override int EnemyCount
        {
            get => base.EnemyCount;
            init
            {
                if ((3 <= value && value <= 8) == false)
                    throw new Exception("Harita ismi 15 karakterden fazla olamaz.");

                base.EnemyCount = value;
            }
        }

        public Map(string mapName, int enemyCount) : base(mapName, enemyCount)
        {

        }
    }
}
