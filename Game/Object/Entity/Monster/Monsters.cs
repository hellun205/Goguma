using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
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
              new DroppingItem(Items.Get(ItemList.POTION_1), 80),
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
              new DroppingItem(Items.Get(ItemList.GOBLINS_ARMOR), 30),
              new DroppingItem(Items.Get(ItemList.POTION_1), 80),
            })
          };

          return resultMonster;
        case MonsterList.GOLD_GOBLIN:
          resultMonster = new Monster()
          {
            Name = "황금 고블린",
            Descriptions = CTexts.Make($"{{와! 황금색 고블린이다. 죽이면 }}{{보물,{Colors.txtWarning}}}{{을 줄지도 모른다.}}"),
            Level = 17,
            MaxHp = 80,
            Hp = 80,
            AttDmg = 4.7,
            DefPer = 2,
            GivingExp = 26,
            GivingGold = 1500 + new Random().Next(10, 750),
            DroppingItems = new DroppingItems(new List<DroppingItem>()
            {
              new DroppingItem(Items.Get(ItemList.GOBLINS_ARMOR), 30),
              new DroppingItem(Items.Get(ItemList.GOLD_GOBLINS_SWORD), 20),
              new DroppingItem(Items.Get(ItemList.GOLD_GOBLIN_COIN), 10),
              new DroppingItem(Items.Get(ItemList.DIAMOND), 6),
              new DroppingItem(Items.Get(ItemList.RED_DIAMOND), 2),
              new DroppingItem(Items.Get(ItemList.EMERALD), 9),
              new DroppingItem(Items.Get(ItemList.GOLD_INGOT), 16),
              new DroppingItem(Items.Get(ItemList.POTION_1), 80),
            })
          };
          resultMonster.AttSystem.Add(Skills.GetMonsterSkill(MSkillList.GOLD_GOBLIN_SWORD_SWING), new AttCondition(Cond.MonsterHpPer, ">=", 0.6));
          resultMonster.AttSystem.Add(Skills.GetMonsterSkill(MSkillList.GOLD_GOBLIN_SWORD_STING), new AttCondition(Cond.MonsterHpPer, ">=", 0.6));
          resultMonster.AttSystem.Add(Skills.GetMonsterSkill(MSkillList.GOLD_GOBLIN_ANGER), new AttCondition(Cond.MonsterHpPer, "<=", 0.5));

          return resultMonster;
        default:
          return null;
      }
    }
  }
}
