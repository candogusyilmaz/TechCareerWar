using System;

using TechCareerWar.Core.Models.Game;
using TechCareerWar.Core.Services;
using TechCareerWar.Core;
using TechCareerWar.Core.Models.Weapons;
using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WeaponStore store = new WeaponStore();

            Map map = new Map("abc", 3);
            Player player = new Player("can");

            player.Inventory.AddWeapon(store.Buy(8));
            player.Inventory.AddWeapon(store.Buy(0));
            player.Inventory.AddWeapon(store.Buy(4));

            //player.ChangeEquippedWeapon(1);

            Game game = new Game(player, map, new ConsoleLogger());

            game.OnPlayerWeaponDisabled += Game_OnPlayerWeaponDisabled;

            game.OnPlayerTurn += Game_OnPlayerTurn;
            game.OnEnemyTurn += Game_OnEnemyTurn;

            game.GameWon += Game_GameWon;
            game.GameLost += Game_GameOver;

            game.StartDuel();
        }

        private static int _i = 1;

        private static void Game_OnPlayerWeaponDisabled(Player player, Weapon disabledWeapon)
        {
            if (disabledWeapon is IHoneable honeable)
            {
                honeable.Hone();
                Console.WriteLine($"P: {disabledWeapon.Brand} {disabledWeapon.Model} honed.");
            }
            else
            {
                player.ChangeEquippedWeapon(_i);

                Console.WriteLine($"P: {disabledWeapon.Brand} {disabledWeapon.Model} changed to {player.EquippedWeapon.Brand} {player.EquippedWeapon.Model}.");
                _i++;
            }
        }

        private static void Game_GameOver(Player player)
        {
            // lost
            //Console.WriteLine("lost");
        }

        private static void Game_GameWon(Player player)
        {
            // won
            //Console.WriteLine("won");
        }

        private static void Game_OnEnemyTurn(Enemy enemy)
        {
            //Console.WriteLine("Enemy: turn" );
        }

        private static void Game_OnPlayerTurn(Player player)
        {
            //Console.WriteLine("player: turn");

            //if (player.EquippedWeapon is Knife knife)
            //    knife.Hone();

            //if (player.EquippedWeapon.Usable == false)
            //{
            //    if (player.Inventory.HasUsableWeapon)
            //    {
            //        player.ChangeEquippedWeapon(_i);
            //        _i++;
            //    }
            //}

            //Console.WriteLine("\t" + player.EquippedWeapon.ToString());

            //try
            //{
            //    player.ExecuteAction();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Player:" + ex.Message);
            //}
        }
    }
}
