using TechCareerWar.Delegates;

namespace TechCareerWar.Models.Game.Abstract
{
    internal interface IAttackable
    {
        event OnAttackHandler OnAttack;
    }
}