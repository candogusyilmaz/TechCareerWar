namespace TechCareerWar.Core
{
    public static class Exceptions
    {
        public const string WeaponsNull = "Silah envanteri oluşturulmamış.";
        public const string WeaponsIndexOutOfReach = "Belirtilen index'te bir silah bulunmamakta.";
        public const string WeaponsContainsWeapon = "Silah zaten bulunmakta.";
        public const string WeaponsItemCountZero = "Silah envanterinde silah bulunmamakta.";
        public const string WeaponNotUsable = "Silah kullanılabilir durumda değil.";
        public const string AttackingWithoutEquippedWeapon = "Silah olmadan saldırı yapılamaz.";
        public const string ActionWhileDead = "Ölüyken eylem yapılamaz.";
        public const string InventoryHasNoUsableWeapons = "Kullanılabilir bir silah bulunmamakta.";
        public const string InventoryMaxItemsReached = "Envanterinize en fazla 3 silah ekleyebilirsiniz.";
        public const string InventoryAlreadyContainsWeapon = "Envanterinizde zaten bu silah bulunmakta.";
        public const string NotPlayerTurn = "Saldırı yapma sırası sizde değil.";
        public const string GameEnded = "Oyun bitmiş.";
        public const string KnifeNotHoned = "Silah bilenmemiş.";
        public const string MapNameTooLong = "Harita ismi 15 karakterden fazla olamaz.";
        public const string FaultyEnemyCount = "Düşman sayısı 3 ila 8 arasında olmalıdır.";
        public const string OutOfBullets = "Mermi kalmadı.";
    }
}
