
using TechCareerWar.Core.Abstract;
using TechCareerWar.Core.Logger.Abstract;
using TechCareerWar.Core.Models.Game;

namespace TechCareerWar.Core
{
    // Logging and giving information and stuff..
    public class Game : GameBase
    {
        public Game(Player player, MapBase map) : base(player, map)
        {

        }

        public Game(Player player, MapBase map, ILogger logger) : base(player, map, logger)
        {

        }
    }
}
