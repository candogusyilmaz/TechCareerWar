namespace TechCareerWar.Core
{
    public static class Exceptions
    {
        public const string WeaponsNull = "Weapons is not initialized.";
        public const string WeaponsIndexOutOfReach = "There are no weapons at index.";
        public const string WeaponsContainsWeapon = "Weapon store already contains weapon.";
        public const string WeaponsItemCountZero = "There are no items in weapon store.";
        public const string WeaponNotUsable = "Weapon is disabled.";
        public const string AttackingWithoutEquippedWeapon = "Can't attack without an equipped weapon.";
        public const string ActionWhileDead = "Can't act while dead.";
        public const string InventoryHasNoUsableWeapons = "There are no usable weapons left.";
        public const string InventoryMaxItemsReached = "You can add maximum of 3 items to your inventory.";
        public const string InventoryAlreadyContainsWeapon = "You already have this weapon in your inventory.";
        public const string NotPlayerTurn = "It's not your turn to attack.";
        public const string GameEnded = "Game ended.";
        public const string KnifeNotHoned = "Weapon is not honed.";
        public const string MapNameTooLong = "Map name can't be more than 15 characters long.";
        public const string FaultyEnemyCount = "Enemy count must be between 3 and 8.";
        public const string OutOfBullets = "Out of bullets.";
    }
}
