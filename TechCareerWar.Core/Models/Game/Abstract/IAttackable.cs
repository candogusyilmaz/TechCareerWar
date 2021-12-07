using TechCareerWar.Core.Delegates;

namespace TechCareerWar.Core.Models.Game.Abstract
{
    public interface IAttackable
    {
        event OnAttackHandler OnAttack;
    }
}