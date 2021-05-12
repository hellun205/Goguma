using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;

namespace Goguma.Game.Object.Entity.Monster
{
  interface IMonster
  {
    string Name { get; set; }
    CTexts Descriptions { get; set; }
    int Hp { get; set; }
    int MaxHp { get; set; }
    int Level { get; set; }

    int AttDmg { get; set; }
    int DefPer { get; set; }

    object Skill { get; set; }
    int GivingGold { get; set; }
    int GivingExp { get; set; }
    List<IItem> DroppingItems { get; set; }

    void AttackPlayer(IPlayer player);
    void PrintAbout();

  }
}
