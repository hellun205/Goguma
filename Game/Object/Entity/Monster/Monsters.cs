using System;
using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Skill;

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
            Name = "강력한 테스트용 몬스터",
            Descriptions = CTexts.Make("{테스트용으로 사용되는 몬스터이다.}"),
            Level = 10,
            MaxHp = 100,
            Hp = 100,
            AttDmg = 4,
            DefPer = 20,
            GivingExp = 120,
            GivingGold = 120 + new Random().Next(0, 100),
            DroppingItems = new DroppingItems(new List<DroppingItem>()
            {
              new DroppingItem(Items.Get(ItemList.TestItem1), 70),
              new DroppingItem(Items.Get(ItemList.TestItem2), 30)
            })
          };
          resultMonster.AttSystem = new AttackSyss()
          {
            Items = new List<AttackSys>()
            {
              new AttackSys(Skills.GetMonsterSkill(MSkillList.TestMonster_TestPunch), new AttCondition(resultMonster.Hp, ">=", 70)),
              new AttackSys(Skills.GetMonsterSkill(MSkillList.TestMonster_TestFireBall), new AttCondition(resultMonster.Hp, ">=", 70)),
              new AttackSys(Skills.GetMonsterSkill(MSkillList.TestMonster_TestAttackSkill), new AttCondition(resultMonster.Hp, ">=", 70)),
              new AttackSys(Skills.GetMonsterSkill(MSkillList.TestMonster_DefensivePosture), new AttCondition(resultMonster.Hp, "<=", 30))
            }
          };
          return resultMonster;
        default:
          return null;
      }
    }
  }
}