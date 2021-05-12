using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item;

namespace Goguma.Game.Object.Entity.Monster
{
  static class Monsters
  {
    static public IMonster Get(MonsterList monster)
    {
      switch (monster)
      {
        case MonsterList.TestMonster:
          var resultMonster = new Monster()
          {
            Name = "테스트용 몬스터",
            Descriptions = CTexts.Make("{테스트용으로 사용되는 몬스터이다.}"),
            Level = 1,
            MaxHp = 10,
            Hp = 10,
            AttDmg = 4,
            DefPer = 0,
            GivingExp = 5,
            GivingGold = 10 + new Random().Next(1, 10),
            DroppingItems = new DroppingItems()
            // adasd as afas as
          };
          return resultMonster;
        default:
          return null;
      }
    }
  }
}