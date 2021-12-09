namespace TechCareerWar.Core.Models.Weapons.Abstract
{
    public interface IHoneable
    {
        bool IsHoned { get; }
        void Hone();
    }

    public interface CopyOfIHoneable
    {
        bool IsHoned { get; }
        void Hone();
    }
}
