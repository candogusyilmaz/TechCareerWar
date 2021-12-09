using TechCareerWar.Core.Delegates;
using TechCareerWar.Core.Enum;
using TechCareerWar.Core.Logger.Abstract;
using TechCareerWar.Core.Models.Game;
using TechCareerWar.Core.Models.Game.Abstract;

namespace TechCareerWar.Core.Abstract
{
    public abstract class GameBase
    {
        private Turn _turn;
        private readonly ILogger _logger;

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

        /// <summary>
        /// Invoked when player has usable weapons but hasn't equipped any.
        /// </summary>
        public event OnWeaponNotEquippedHandler OnPlayerWeaponNotEquipped;
        /// <summary>
        /// Invoked when player's equipped weapon is disabled.
        /// </summary>
        public event OnWeaponDisabledHandler OnPlayerWeaponDisabled;

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

        public GameBase(Player player, MapBase map)
        {
            Player = player;
            Map = map;

            Player.OnAttack += PlayerAttack;
            Player.OnDamageReceived += PlayerDamageRecevied;
            Player.OnMortalDied += PlayerDied;
        }

        public GameBase(Player player, MapBase map, ILogger logger) : this(player, map)
        {
            _logger = logger;
        }

        /// <summary>
        /// Starts the duel with <see cref="Player"/> turn.
        /// </summary>
        public void StartDuel()
        {
            _logger?.Log("SYS: Duel started.");
            EnemySubscribe();

            Turn = Turn.Player;
        }

        private void EnemyDamageRecevied(Mortal mortal)
        {
            _logger?.Log($"SYS: Enemy took damage. HP: {mortal.HP}");

            if (mortal.IsAlive)
                Turn = Turn.Enemy;
        }

        private void EnemyDied(Mortal mortal)
        {
            _logger?.Log("SYS: Enemy died, duel won.");
            EnemyUnsubscribe();

            if (Map.AliveEnemyCount > 0)
                StartDuel();
            else
            {
                _logger?.Log("SYS: There is no alive enemy left. Player won.");
                GameWon?.Invoke(Player);
            }
        }

        private void PlayerTurn()
        {
            _logger?.Log("SYS: Turn changes to Player.");

            if (Player.Inventory.HasUsableWeapon)
            {
                if (Player.EquippedWeapon == null)
                {
                    _logger?.Log("SYS: Player has no equipped weapon. Equip a weapon.");
                    OnPlayerWeaponNotEquipped?.Invoke(Player);
                }

                if (Player.EquippedWeapon != null && Player.EquippedWeapon.Usable is false)
                {
                    _logger?.Log("SYS: Player's equipped weapon is disabled. Choose a new one.");
                    OnPlayerWeaponDisabled?.Invoke(Player, Player.EquippedWeapon);
                }
                else
                {
                    _logger?.Log("SYS: Player has no weapon. Player loses.");
                    Player.ReceiveDamage(Player.HP);
                    return;
                }

                OnPlayerTurn?.Invoke(Player);
                Player.ExecuteAction();
            }
            else
            {
                _logger?.Log("SYS: Player has no usable weapon.");
                Player.ReceiveDamage(Player.HP);
            }
        }

        private void PlayerAttack(int damage)
        {
            _logger?.Log($"SYS: Player attacked with {damage} damage.");

            Enemy.ReceiveDamage(damage);
        }

        private void EnemyTurn()
        {
            _logger?.Log("SYS: Turn changes to Enemy.");

            if (Enemy.EquippedWeapon.Usable)
            {
                OnEnemyTurn?.Invoke(Enemy);
                Enemy.ExecuteAction();
            }
            else
            {
                _logger?.Log("SYS: Enemy has no usable weapon.");
                Enemy.ReceiveDamage(Enemy.HP);
            }
        }

        private void EnemyAttack(int damage)
        {
            _logger?.Log($"SYS: Enemy attacked with {damage} damage.");

            Player.ReceiveDamage(damage);
        }

        private void PlayerDamageRecevied(Mortal mortal)
        {
            _logger?.Log($"SYS: Player took damage. HP: {mortal.HP}");
            if (Player.IsAlive)
                Turn = Turn.Player;
        }

        private void PlayerDied(Mortal mortal)
        {
            _logger?.Log("SYS: Player died, game lost.");

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
            if(Enemy is IAttackable e) {}
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
