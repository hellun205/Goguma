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
    static public IMonster GetInstance(MonsterList monster)
    {
      switch (monster)
      {
        case MonsterList.TEST_MONSTER: return M_TestMonster;
        case MonsterList.SLIME: return M_Slime;
        case MonsterList.GOBLIN: return M_Goblin;
        case MonsterList.GOLD_GOBLIN: return M_GoldGoblin;
        default: return null;
      }
    }

    static public IMonster GetNew(MonsterList monster)
    {
      switch (monster)
      {
        case MonsterList.TEST_MONSTER: return new Mob_TestMonster();
        case MonsterList.SLIME: return new Mob_Slime();
        case MonsterList.GOBLIN: return new Mob_Goblin();
        case MonsterList.GOLD_GOBLIN: return new Mob_GoldGoblin();
        default: return null;
      }
    }
  }
}
