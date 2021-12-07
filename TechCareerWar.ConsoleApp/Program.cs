using System;

using TechCareerWar.Core.Models.Game;
using TechCareerWar.Core.Services;
using TechCareerWar.Core;
using TechCareerWar.Core.Models.Weapons;

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
            player.Inventory.AddWeapon(store.Buy(7));
            player.Inventory.AddWeapon(store.Buy(4));

            player.ChangeEquippedWeapon(0);

            Game game = new Game(player, map, new ConsoleLogger());

            game.OnPlayerTurn += Game_OnPlayerTurn;
            game.OnEnemyTurn += Game_OnEnemyTurn;

            game.GameWon += Game_GameWon;
            game.GameLost += Game_GameOver;

            game.StartDuel();
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

        private static int _i = 1;

        private static void Game_OnPlayerTurn(Player player)
        {
            //Console.WriteLine("player: turn");

            //if (player.EquippedWeapon is Knife knife)
            //    knife.Hone();

            if (player.EquippedWeapon.Usable == false)
            {
                if (player.Inventory.HasUsableWeapon)
                {
                    player.ChangeEquippedWeapon(_i);
                    _i++;
                }
            }

            //Console.WriteLine("\t" + player.EquippedWeapon.ToString());

            try
            {
                player.ExecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Player:" + ex.Message);
            }
        }
    }
}
