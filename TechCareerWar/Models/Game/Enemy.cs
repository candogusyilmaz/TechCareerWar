using System;

using TechCareerWar.Delegates;
using TechCareerWar.Models.Game.Abstract;
using TechCareerWar.Models.Weapons.Abstract;

namespace TechCareerWar.Models.Game
{
    internal class Enemy : Mortal, IAttackable
    {
        public event OnAttackHandler OnAttack;

        public Weapon EquippedWeapon { get; init; }

        public Enemy(int hp, Weapon weapon) : base(hp)
        {
            EquippedWeapon = weapon;
        }

        protected override void Action()
        {
            // Eğer yanlışlıkla düşmanımıza silah vermeyi unutursak diye..
            if (EquippedWeapon == null)
                throw new Exception(Exceptions.AttackingWithoutEquippedWeapon);

            OnAttack?.Invoke(EquippedWeapon.Use());
        }
    }
}
