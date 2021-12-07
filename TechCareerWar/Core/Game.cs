
using System;

using TechCareerWar.Core.Abstract;
using TechCareerWar.Delegates;
using TechCareerWar.Enum;
using TechCareerWar.Models.Game;
using TechCareerWar.Models.Game.Abstract;

namespace TechCareerWar.Core
{
    internal class Game
    {
        private Turn _turn;

        /// <summary>
        /// Invoked when game lost.
        /// </summary>
        public event OnGameEndHandler GameLost;
        /// <summary>
        /// Invoked when game won.
        /// </summary>
        public event OnGameEndHandler GameWon;

        /// <summary>
        /// Invoked when <see cref="Turn"/> is <see cref="Turn.Player"/>.
        /// </summary>
        public event OnPlayerTurnHandler OnPlayerTurn;
        /// <summary>
        /// Invoked when <see cref="Turn"/> is <see cref="Turn.Enemy"/>.
        /// </summary>
        public event OnEnemyTurnHandler OnEnemyTurn;

        public Player Player { get; init; }
        public Enemy Enemy { get; private set; }

        public MapBase Map { get; init; }
        public Turn Turn
        {
            get => _turn;
            private set
            {
                _turn = value;
                if (Turn == Turn.Player)
                    PlayerTurn();
                else if (Turn == Turn.Enemy)
                    EnemyTurn();
            }
        }

        public Game(Player player, MapBase map)
        {
            Player = player;
            Map = map;

            Player.OnAttack += PlayerAttack;
            Player.OnDamageReceived += PlayerDamageRecevied;
            Player.OnMortalDied += PlayerDied;
        }

        /// <summary>
        /// Starts the duel with <see cref="Player"/> turn.
        /// </summary>
        public void StartDuel()
        {
            EnemySubscribe();

            Turn = Turn.Player;
        }

        private void EnemyDamageRecevied(Mortal mortal)
        {
            if (mortal.IsAlive)
            {
                Turn = Turn.Enemy;
            }
        }

        private void EnemyDied(Mortal mortal)
        {
            Console.WriteLine("SYS: Enemy died, duel won.");
            EnemyUnsubscribe();

            if (Map.AliveEnemyCount > 0)
            {
                StartDuel();
            }
            else
            {
                Console.WriteLine("SYS: There is no alive enemy left. Player won.");
                GameWon?.Invoke(Player);
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("SYS: Turn changes to Player.");

            if (Player.Inventory.HasUsableWeapon)
            {
                OnPlayerTurn?.Invoke(Player);
            }
            else
            {
                Console.WriteLine("SYS: Player has no usable weapon.");
                Player.ReceiveDamage(Player.HP);
            }
        }

        private void PlayerAttack(int damage)
        {
            Console.WriteLine($"SYS: Player attacked with {damage} damage. Enemy HP: {Enemy.HP}.");

            Enemy.ReceiveDamage(damage);
        }

        private void EnemyTurn()
        {
            Console.WriteLine("SYS: Turn changes to Enemy.");

            if (Enemy.EquippedWeapon.Usable)
            {
                OnEnemyTurn?.Invoke(Enemy);
                Enemy.ExecuteAction();
            }
            else
            {
                Console.WriteLine("SYS: Enemy has no usable weapon.");
                Enemy.ReceiveDamage(Enemy.HP);
            }
        }

        private void EnemyAttack(int damage)
        {
            Console.WriteLine($"SYS: Enemy attacked {damage} damage. Player HP: {Player.HP}.");

            Player.ReceiveDamage(damage);
        }

        private void PlayerDamageRecevied(Mortal mortal)
        {
            if (Player.IsAlive)
            {
                Turn = Turn.Player;
            }
        }

        private void PlayerDied(Mortal mortal)
        {
            Console.WriteLine("SYS: Player died, game lost.");

            EnemyUnsubscribe();
            PlayerUnsubscribe();

            GameLost?.Invoke(Player);
        }

        private void EnemySubscribe()
        {
            Enemy = Map.GetAliveEnemy();
            Enemy.OnAttack += EnemyAttack;
            Enemy.OnDamageReceived += EnemyDamageRecevied;
            Enemy.OnMortalDied += EnemyDied;
        }

        private void EnemyUnsubscribe()
        {
            Enemy.OnAttack -= EnemyAttack;
            Enemy.OnDamageReceived -= EnemyDamageRecevied;
            Enemy.OnMortalDied -= EnemyDied;

            Enemy = null;
        }

        private void PlayerUnsubscribe()
        {
            Player.OnAttack -= PlayerAttack;
            Player.OnDamageReceived -= PlayerDamageRecevied;
            Player.OnMortalDied -= PlayerDied;
        }
    }
}
