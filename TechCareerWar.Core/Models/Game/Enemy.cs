using System;

using TechCareerWar.Core.Delegates;
using TechCareerWar.Core.Models.Game.Abstract;
using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.Core.Models.Game
{
    public class Enemy : Mortal, IAttackable
    {
        public event OnAttackHandler OnAttack;

        public Weapon EquippedWeapon { get; init; }

        public Enemy(int hp, Weapon weapon) : base(hp)
        {
            EquippedWeapon = weapon;
        }

        /// <summary>
        /// Attacks with the weapon.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        protected override void Action()
        {
            // Eğer yanlışlıkla düşmanımıza silah vermeyi unutursak diye..
            if (EquippedWeapon == null)
                throw new ArgumentNullException(Exceptions.AttackingWithoutEquippedWeapon);

            OnAttack?.Invoke(EquippedWeapon.Use());
        }
    }
}
