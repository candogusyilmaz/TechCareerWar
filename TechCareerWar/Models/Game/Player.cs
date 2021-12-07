using System;

using TechCareerWar.Delegates;
using TechCareerWar.Models.Game.Abstract;
using TechCareerWar.Models.Weapons.Abstract;
using TechCareerWar.Utilities;

namespace TechCareerWar.Models.Game
{
    internal class Player : Mortal, IAttackable
    {
        public event OnAttackHandler OnAttack;

        public string Name { get; init; }
        public Inventory Inventory { get; init; }
        public Weapon EquippedWeapon { get; private set; }

        public Player(string name) : base(100)
        {
            Name = name;
            Inventory = new Inventory();
        }

        protected override void Action()
        {
            if (Inventory.HasUsableWeapon == false)
                throw new Exception(Exceptions.InventoryHasNoUsableWeapons);

            Attack();
        }

        public void ChangeEquippedWeapon(int index)
        {
            EquippedWeapon = Inventory.Weapons[index];
        }

        private void Attack()
        {
            if (EquippedWeapon == null)
                throw new Exception(Exceptions.AttackingWithoutEquippedWeapon);

            OnAttack?.Invoke(EquippedWeapon.Use());
        }
    }
}
