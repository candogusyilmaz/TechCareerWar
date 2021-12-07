using System;

using TechCareerWar.Delegates;

namespace TechCareerWar.Models.Game.Abstract
{
    public abstract class Mortal
    {
        public event OnMortalDiedHandler OnMortalDied;
        public event OnReceiveDamageHandler OnDamageReceived;

        public int HP { get; private set; }
        public bool IsAlive => HP > 0;

        public Mortal(int hp)
        {
            HP = hp;
        }

        /// <summary>
        /// Reduces the HP by the incoming <paramref name="damage"/>.
        /// If <see cref="IsAlive"/> is false then no action will be done.
        /// If <see cref="HP"/> goes below 0 <see cref="OnMortalDied"/> will be invoked.
        /// </summary>
        /// <param name="damage">Damage to receive</param>
        public virtual void ReceiveDamage(int damage)
        {
            if (IsAlive == false)
                throw new Exception("Ölüyken daha fazla hasar alamayız.");

            HP -= damage;
            OnDamageReceived?.Invoke(this);

            if (IsAlive == false)
                OnMortalDied?.Invoke(this);
        }

        protected abstract void Action();

        /// <summary>
        /// Executes the action of the <see cref="Mortal"/> class.
        /// Exception will be thrown if used while dead.
        /// </summary>
        /// <exception cref="Exceptions.ActionWhileDead"></exception>
        public void ExecuteAction()
        {
            if (IsAlive == false)
                throw new Exception(Exceptions.ActionWhileDead);

            Action();
        }
    }
}
