using TechCareerWar.Core.Models.Game;
using TechCareerWar.Core.Models.Weapons.Abstract;

namespace TechCareerWar.Core.Delegates
{
    public delegate void OnWeaponDisabledHandler(Player player, Weapon disabledWeapon);
}
