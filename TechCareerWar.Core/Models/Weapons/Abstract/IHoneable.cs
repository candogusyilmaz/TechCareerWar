namespace TechCareerWar.Core.Models.Weapons.Abstract
{
    internal interface IHoneable
    {
        bool IsHoned { get; }
        void Hone();
    }
}
