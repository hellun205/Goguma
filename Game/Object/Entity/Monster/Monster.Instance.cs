using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Entity.Monster.Monsters;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity.Monster
{
  public static partial class Monster
  {
    static public readonly Mob M_TestMonster = new Mob_TestMonster();
    static public readonly Mob M_Slime = new Mob_Slime();
    static public readonly Mob M_Goblin = new Mob_Goblin();
    static public readonly Mob M_GoldGoblin = new Mob_GoldGoblin();
  }
}
