using System;
using System.Collections.Generic;
using Gogu_Remaster.Game.Object.Inventory.Item;
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
      var resultMonster = new Monster();
      switch (monster)
      {
        case MonsterList.TEST_MONSTER:
          resultMonster = new Monster()
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
              new DroppingItem(Items.Get(ItemList.TEST_ITEM1), 70),
              new DroppingItem(Items.Get(ItemList.TEST_ITEM2), 30)
            })
          };
          resultMonster.AttSystem.Add(Skills.GetMonsterSkill(MSkillList.TestMonster_TestPunch), new AttCondition(Cond.MonsterHpPer, ">=", 0.7));
          resultMonster.AttSystem.Add(Skills.GetMonsterSkill(MSkillList.TestMonster_TestFireBall), new AttCondition(Cond.PlayerHpPer, "<=", 0.3));
          resultMonster.AttSystem.Add(Skills.GetMonsterSkill(MSkillList.TestMonster_TestAttackSkill), new AttCondition(Cond.MonsterHpPer, ">=", 0.7));
          resultMonster.AttSystem.Add(Skills.GetMonsterSkill(MSkillList.TestMonster_DefensivePosture), new AttCondition(Cond.MonsterHpPer, "<=", 0.4));

          return resultMonster;
        case MonsterList.SLIME:
          resultMonster = new Monster()
          {
            Name = "슬라임",
            Descriptions = CTexts.Make("{끈적끈적하니 기분이 더럽다.}"),
            Level = 2,
            MaxHp = 5,
            Hp = 5,
            AttDmg = 2,
            DefPer = 0.2,
            GivingExp = 7.5,
            GivingGold = 10 + new Random().Next(0, 10),
            DroppingItems = new DroppingItems(new List<DroppingItem>()
            {
              new DroppingItem(Items.Get(ItemList.STICKY_LIQUID), 80),
            })
          };
          resultMonster.AttSystem.Add(Skills.GetMonsterSkill(MSkillList.SLIME_STICKY_ATTACK), new AttCondition(Cond.MonsterHpPer, ">=", 0.7));
          resultMonster.AttSystem.Add(Skills.GetMonsterSkill(MSkillList.SLIME_SPOUT_STICKY_LIQUID), new AttCondition(Cond.PlayerHpPer, "<=", 0.5));

          return resultMonster;
        case MonsterList.GOBLIN:
          resultMonster = new Monster()
          {
            Name = "고블린",
            Descriptions = CTexts.Make("{못생겼다.}"),
            Level = 3,
            MaxHp = 7,
            Hp = 7,
            AttDmg = 2.6,
            DefPer = 0.3,
            GivingExp = 8.4,
            GivingGold = 17 + new Random().Next(0, 16),
            DroppingItems = new DroppingItems(new List<DroppingItem>()
            {
              new DroppingItem(Items.Get(ItemList.GOBLINS_SWORD), 35),
              new DroppingItem(Items.Get(ItemList.GOBLINS_ARMOR), 30)
            })
          };

          return resultMonster;
        default:
          return null;
      }
    }
  }
}
